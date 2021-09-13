using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private Func<IUnitOfWork> _unitFactory;

        public AuthenticationService(Func<IUnitOfWork> unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public async Task<UserDto> AuthorizeAsync(string name, string password)
        {
            User user;

            using(var unit = _unitFactory())
            {
                try
                {
                    user = await unit.Users.GetWithProjectsAsync(u => u.Name == name && u.Password == password);
                }
                catch
                {
                    throw new Exception();
                }
            }

            return MapToDto(user);
        }

        public async Task RegisterAsync(string name, string password)
        {
            using(var unit = _unitFactory())
            {
                if ((await unit.Users.GetAsync(u => u.Name == name)).FirstOrDefault() == null)
                {
                    unit.Users.Add(new User() { Name = name, Password = password });
                    await unit.SaveAsync();
                }
                else
                    throw new TakenNameException();
            }
        }

        private UserDto MapToDto(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = config.CreateMapper();
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}