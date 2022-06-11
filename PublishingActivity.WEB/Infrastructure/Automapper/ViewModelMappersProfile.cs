using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PublishingActivity.BLL.DTO;
using PublishingActivity.WEB.Models.PublicationVM;

namespace PublishingActivity.WEB.Infrastructure.Automapper
{
    public static class ViewModelMappersProfile
    {
        #region PublicationDTO -> PublicationViewModel
        public static PublicationViewModel ToDisplayVM(this PublicationDTO model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PublicationDTO, PublicationViewModel>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                        .ForMember("ProfessorName", opt => opt.MapFrom(x => x.ProfessorName))
                        .ForMember("Subject", opt => opt.MapFrom(x => x.Subject))
                        .ForMember("CoAuthors", opt => opt.MapFrom(x => x.CoAuthors))
                        .ForMember("LocationAndDate", opt => opt.MapFrom(x => x.LocationAndDate))
                        .ForMember("Pages", opt => opt.MapFrom(x => x.Pages))
                        .ForMember("Year", opt => opt.MapFrom(x => x.Year));
                })
                .CreateMapper()
                .Map<PublicationDTO, PublicationViewModel>(model);
        }
        #endregion

        #region IEnumerable<PublicationDTO> -> IEnumerable<PublicationViewModel>
        public static IEnumerable<PublicationViewModel> ToDisplayVM(this IEnumerable<PublicationDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion
        
        #region IEnumerable<PublicationEditModel> -> IEnumerable<PublicationDTO>
        public static IEnumerable<PublicationDTO> ToDTO(this IEnumerable<PublicationEditModel> models)
        {
            return models.Select(x => x.ToDTO());
        }
        #endregion

        #region PublicationDTO -> PublicationEditModel
        public static PublicationEditModel ToEditVM(this PublicationDTO model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PublicationDTO, PublicationEditModel>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("ProfessorName", opt => opt.MapFrom(x => x.ProfessorName))
                        .ForMember("Subject", opt => opt.MapFrom(x => x.Subject))
                        .ForMember("CoAuthors", opt => opt.MapFrom(x => x.CoAuthors))
                        .ForMember("LocationAndDate", opt => opt.MapFrom(x => x.LocationAndDate))
                        .ForMember("Pages", opt => opt.MapFrom(x => x.Pages))
                        .ForMember("Year", opt => opt.MapFrom(x => x.Year));
                })
                .CreateMapper()
                .Map<PublicationDTO, PublicationEditModel>(model);
        }
        #endregion
        
        #region PublicationEditModel -> PublicationDTO
        public static PublicationDTO ToDTO(this PublicationEditModel model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PublicationEditModel, PublicationDTO>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("ProfessorName", opt => opt.MapFrom(x => x.ProfessorName))
                        .ForMember("Subject", opt => opt.MapFrom(x => x.Subject))
                        .ForMember("CoAuthors", opt => opt.MapFrom(x => x.CoAuthors))
                        .ForMember("LocationAndDate", opt => opt.MapFrom(x => x.LocationAndDate))
                        .ForMember("Pages", opt => opt.MapFrom(x => x.Pages))
                        .ForMember("Year", opt => opt.MapFrom(x => x.Year));
                })
                .CreateMapper()
                .Map<PublicationEditModel, PublicationDTO>(model);
        }
        #endregion
    }
}