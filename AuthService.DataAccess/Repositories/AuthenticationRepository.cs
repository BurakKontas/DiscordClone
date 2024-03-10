using AuthService.DataAccess.Contracts;
using AuthService.Domain;
using AuthService.Domain.Models;
using AuthService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AuthService.DataAccess.Repositories
{
    public class AuthenticationRepository(AuthContext context) : IAuthenticationRepository
    {
        private readonly AuthContext _context = context;

        public async Task<bool> AddUser(Auth user)
        {
            await _context.Auths.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(Auth user)
        {
            _context.Auths.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BanUser(Ban ban)
        {
            await _context.Bans.AddAsync(ban);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnbanUser(Guid userUuid)
        {
            var userBan = await _context.Bans.FirstOrDefaultAsync(b => b.Useruuid == userUuid);
            if (userBan != null)
            {
                _context.Bans.Remove(userBan);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UserExists(Guid userUuid)
        {
            return await _context.Auths.AnyAsync(a => a.Useruuid == userUuid);
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Auths.AnyAsync(a => a.Email == email);
        }

        public async Task<Auth?> GetUser(Guid userUuid)
        {
            return await _context.Auths.Include(x => x.Role).FirstOrDefaultAsync(a => a.Useruuid == userUuid);
        }

        public async Task<Auth?> GetUser(string email)
        {
            return await _context.Auths.Include(x => x.Role).FirstOrDefaultAsync(a => a.Email == email);
        }

        public Task<Role?> GetRole(int roleId)
        {
            return _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public Task<Role?> GetRole(string roleName)
        {
            return _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}
