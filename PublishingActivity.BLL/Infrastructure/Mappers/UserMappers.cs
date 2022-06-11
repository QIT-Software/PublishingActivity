using System.Collections.Generic;
using System.Linq;
using PublishingActivity.BLL.DTO;
using PublishingActivity.DAL.Entities;
using AutoMapper;

namespace PublishingActivity.BLL.Infrastructure.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToDTO(this ApplicationUser model)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ApplicationUser, UserDTO>()
                        .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                        .ForMember("Email", opt => opt.MapFrom(x => x.Email))
                        .ForMember("UserName", opt => opt.MapFrom(x => x.UserName));
                })
                .CreateMapper()
                .Map<ApplicationUser, UserDTO>(model);
        }
        public static IEnumerable<UserDTO> ToDTO(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
