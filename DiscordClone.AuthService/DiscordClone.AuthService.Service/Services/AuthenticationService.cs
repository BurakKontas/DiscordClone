using DiscordClone.AuthService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.AuthService.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<BanUserResponse> BanUser(BanUserRequest banUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ForgotPasswordRequest> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> LoginUser(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterResponse> RegisterUser(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public Task<UnbanUserResponse> UnbanUser(UnbanUserRequest unbanUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
