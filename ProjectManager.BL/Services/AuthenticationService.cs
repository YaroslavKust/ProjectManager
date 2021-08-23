using System;
using System.Linq;
using System.Threading.Tasks;
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
            var user = 
                (await _unit.Users.GetAsync(u => u.Name == name && u.Password == password)).FirstOrDefault();
            return new UserDto() {Id = user.Id, Name = user.Name};
        }

        public async void Register(string name, string password)
        {
            if ((await _unit.Users.GetAsync(u => u.Name == name)).FirstOrDefault() == null)
                _unit.Users.Add(new User() {Name = name, Password = password});
            else
                throw new Exception();
        }
    }
}