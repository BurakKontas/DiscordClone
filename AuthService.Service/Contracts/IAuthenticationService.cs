using AuthService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Service.Contracts
{
    public interface IAuthenticationService
    {
        public Task<RegisterResponse> RegisterUser(RegisterRequest registerRequest);
        public Task<LoginResponse> LoginUser(LoginRequest loginRequest, string? refreshToken);
        public Task<LoginResponse> LoginUser(RefreshTokenRequest refreshTokenRequest);
        public Task<BanUserResponse> BanUser(BanUserRequest banUserRequest);
        public Task<UnbanUserResponse> UnbanUser(UnbanUserRequest unbanUserRequest);
        public Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);
    }
}
