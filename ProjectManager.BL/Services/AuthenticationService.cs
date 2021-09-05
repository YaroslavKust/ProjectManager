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
        private IUnitOfWork _unit;

        public AuthenticationService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<UserDto> AuthorizeAsync(string name, string password)
        {
            User user;

            try
            {
                user = await _unit.Users.GetWithProjectsAsync(u => u.Name == name && u.Password == password);
            }
            catch
            {
                throw new Exception();
            }

            return MapToDto(user);
        }

        public async Task RegisterAsync(string name, string password)
        {
            if ((await _unit.Users.GetAsync(u => u.Name == name)).FirstOrDefault() == null)
            {
                _unit.Users.Add(new User() {Name = name, Password = password});
                await _unit.SaveAsync();
            }
            else
                throw new TakenNameException();
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