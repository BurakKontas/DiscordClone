using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.CenterService.Service.Services
{
    public class AuthenticationService(AuthContext context) : IAuthenticationService
    {
        private readonly AuthContext _context = context;
        public async Task<BanUserResponse> BanUserAsync(BanUserRequest request)
        {
            var reply = await _context.Client.BanUserAsync(request);
            return reply;
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var reply = await _context.Client.ForgotPasswordAsync(request);
            return reply;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var reply = await _context.Client.LoginAsync(request);
            return reply;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var reply = await _context.Client.RegisterAsync(request);
            return reply;
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var reply = await _context.Client.RefreshTokenAsync(request);
            return reply;
        }

        public async Task<TokenValidationResponse> ValidateTokenAsync(TokenValidationRequest request)
        {
            var reply = await _context.Client.ValidateTokenAsync(request);
            return reply;
        }

        public async Task<UnbanUserResponse> UnbanUserAsync(UnbanUserRequest request)
        {
            var reply = await _context.Client.UnbanUserAsync(request);
            return reply;
        }   
    }
}
