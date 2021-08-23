﻿using System.Threading.Tasks;
using ProjectManager.BL.DTO;

namespace ProjectManager.BL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> AuthorizeAsync(string name, string password);
        void Register(string name, string password);
    }
}