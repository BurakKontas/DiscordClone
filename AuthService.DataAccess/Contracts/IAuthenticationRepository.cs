﻿using AuthService.Domain;
using AuthService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.DataAccess.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<bool> AddUser(Auth user);
        Task<bool> UpdateUser(Auth user);
        Task<bool> BanUser(Ban ban);
        Task<bool> UnbanUser(Guid userUuid);
        Task<bool> UserExists(Guid userUuid);
        Task<bool> UserExists(string email);
        Task<Auth?> GetUser(Guid userUuid);
        Task<Auth?> GetUser(string email);
        Task<Role?> GetRole(int roleId);
        Task<Role?> GetRole(string roleName);

    }
}
