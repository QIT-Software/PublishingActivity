using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
using PublicationActivity.Shared;
using PublishingActivity.BLL.DTO;
using PublishingActivity.BLL.Infrastructure;
using PublishingActivity.BLL.Infrastructure.Mappers;
using PublishingActivity.BLL.Interfaces;
using PublishingActivity.BLL.Models;
using PublishingActivity.DAL.Entities;
using PublishingActivity.DAL.Interfaces;

namespace PublishingActivity.BLL.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        Logger log = LogManager.GetCurrentClassLogger();

        public PublicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PublicationDTO> GetAllPublication(string proffesorId)
        {
            return _unitOfWork.PublicationRepository.Get(publication => publication.IsDeleted == false && publication.Professor.Id == proffesorId).ToDTO();
        }

        public PublicationDTO GetPublicationById(int id)
        {
            return _unitOfWork.PublicationRepository.GetById(id).ToDTO();
        }

        public OperationDetails AddPublication(PublicationDTO publication, string proffesorId)
        {
            var newPublication = publication.ToEntity();
            if (_unitOfWork.ClientManager.GetById(proffesorId) != null)
                newPublication.Professor = _unitOfWork.ClientManager.GetById(proffesorId);
            else
            {
                log.Error($"Proffesor id [{proffesorId}] not found");
                return new OperationDetails(false, "Proffesor not found", "");
            }
            var status = new PublicationStatusTracker()
            {
                Date = DateTime.Now,
                Status = PublicationStatus.Uploaded,
                Publication = newPublication
            };
            newPublication.Statuses.Add(status);

            _unitOfWork.PublicationRepository.Create(newPublication);
            log.Info($"Publication [{publication.Subject}] was created");
            return new OperationDetails(true, $"Publication {newPublication.Subject} has been created","");
        }

        public OperationDetails EditPublication(PublicationDTO publication)
        {
            var tempPublication = publication.ToEntity();
            _unitOfWork.PublicationRepository.Update(tempPublication);
            var status = new PublicationStatusTracker()
            {
                Publication = tempPublication,
                Status = PublicationStatus.Modified
            };
            _unitOfWork.PublicationStatusTrackerRepository.Create(status);
            log.Info($"Publication [{publication.Subject}] was updated");
            return new OperationDetails(true, $"Publication {tempPublication.Subject} has been updated", "");
        }

        public OperationDetails SoftDeletePublication(int publicationId)
        {
            if (_unitOfWork.PublicationRepository.GetById(publicationId) == null)
            {
                log.Error($"Proffesor id [{publicationId}] not found");
                return new OperationDetails(false, "Publication not found", "");
            }
            var publication = _unitOfWork.PublicationRepository.GetById(publicationId);
            publication.IsDeleted = true;

            _unitOfWork.PublicationRepository.Update(publication);
            var status = new PublicationStatusTracker()
            {
                Publication = publication,
                Status = PublicationStatus.Deleted
            };
            _unitOfWork.PublicationStatusTrackerRepository.Create(status);
            log.Info($"Publication [{publication.Subject}] was deleted");
            return new OperationDetails(true, $"Publication {publication.Subject} has been deleted", "");
        }

        public Dictionary<int, int> AllPublicationsByYears(string proffesorId)
        {
            var publications = _unitOfWork.PublicationRepository.Get(publication => publication.IsDeleted == false && publication.Professor.Id == proffesorId).OrderBy(p => p.Year);

            var allPublicationsByYears = new Dictionary<int, int>();

            foreach (var publication in publications)
            {
                if (allPublicationsByYears.ContainsKey(publication.Year))
                    allPublicationsByYears[publication.Year] += 1;
                else
                    allPublicationsByYears.Add(publication.Year, 1);
            }

            return allPublicationsByYears;
        }

        public Stream ToCSV(string proffesorId)
        {
            return Parser.ToCSV(_unitOfWork.PublicationRepository
                .Get(publication => publication.IsDeleted == false && publication.Professor.Id == proffesorId)
                .OrderBy(p => p.Year));
        }
    }
}
