using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PublishingActivity.BLL.DTO;
using PublishingActivity.DAL.Entities;

namespace PublishingActivity.BLL.Infrastructure.Mappers
{
    public static class PublicationMapper
    {
        public static PublicationDTO ToDTO(this Publication model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Publication, PublicationDTO>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("ProfessorName", opt => opt.MapFrom(x => x.ProfessorName))
                        .ForMember("Subject", opt => opt.MapFrom(x => x.Subject))
                        .ForMember("CoAuthors", opt => opt.MapFrom(x => x.CoAuthors))
                        .ForMember("LocationAndDate", opt => opt.MapFrom(x => x.LocationAndDate))
                        .ForMember("Pages", opt => opt.MapFrom(x => x.Pages))
                        .ForMember("Year", opt => opt.MapFrom(x => x.Year));
                })
                .CreateMapper()
                .Map<Publication, PublicationDTO>(model);
        }
        public static IEnumerable<PublicationDTO> ToDTO(this IEnumerable<Publication> models)
        {
            return models.Select(x => x.ToDTO());
        }

        public static Publication ToEntity(this PublicationDTO model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PublicationDTO, Publication>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("ProfessorName", opt => opt.MapFrom(x => x.ProfessorName))
                        .ForMember("Subject", opt => opt.MapFrom(x => x.Subject))
                        .ForMember("CoAuthors", opt => opt.MapFrom(x => x.CoAuthors))
                        .ForMember("LocationAndDate", opt => opt.MapFrom(x => x.LocationAndDate))
                        .ForMember("Pages", opt => opt.MapFrom(x => x.Pages))
                        .ForMember("Year", opt => opt.MapFrom(x => x.Year));
                })
                .CreateMapper()
                .Map<PublicationDTO, Publication>(model);
        }
        public static IEnumerable<Publication> ToEntity(this IEnumerable<PublicationDTO> models)
        {
            return models.Select(x => x.ToEntity());
        }
    }
}
