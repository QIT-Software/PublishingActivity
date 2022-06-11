using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PublishingActivity.BLL.DTO;
using PublishingActivity.BLL.Infrastructure;
 
namespace PublishingActivity.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    } 
}