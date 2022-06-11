using PublishingActivity.BLL.DTO;
using PublishingActivity.BLL.Infrastructure;
using PublishingActivity.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using PublishingActivity.BLL.Interfaces;
using PublishingActivity.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace PublishingActivity.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork { get; set; }
        Logger log = LogManager.GetCurrentClassLogger();

        public UserService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _unitOfWork.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                ProfessorProfile clientProfile = new ProfessorProfile { Id = user.Id, Name = userDto.Name, Email = userDto.Email };
                _unitOfWork.ClientManager.Create(clientProfile);
                await _unitOfWork.SaveAsync();
                log.Info($"user [{userDto.Name}] was created");
                return new OperationDetails(true, "Реєстрація успішно пройдена", "");
            }
            return new OperationDetails(false, "Користувач з таким логіном вже існує", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _unitOfWork.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await _unitOfWork.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _unitOfWork.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _unitOfWork.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}