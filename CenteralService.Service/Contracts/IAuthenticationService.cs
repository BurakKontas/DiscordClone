using CenteralService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenteralService.Service.Contracts
{
    public interface IAuthenticationService
    {
        public Task<TokenValidationResponse> ValidateTokenAsync(TokenValidationRequest request);
        public Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request);
        public Task<LoginResponse> LoginAsync(LoginRequest request);
        public Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        public Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
        public Task<BanUserResponse> BanUserAsync(BanUserRequest request);
        public Task<UnbanUserResponse> UnbanUserAsync(UnbanUserRequest request);
        public Task<ExtractTokenResponse> ExtractTokenAsync(ExtractTokenRequest request);
    }
}
