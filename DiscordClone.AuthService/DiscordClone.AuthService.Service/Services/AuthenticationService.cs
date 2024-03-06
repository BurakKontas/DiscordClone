using DiscordClone.AuthService.DataAccess.Contracts;
using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Domain.Models;
using DiscordClone.AuthService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.AuthService.Service.Services
{
    public class AuthenticationService(IAuthenticationRepository authenticationRepository, ITokenService tokenService) : IAuthenticationService
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IAuthenticationRepository _authenticationRepository = authenticationRepository;

        public async Task<BanUserResponse> BanUser(BanUserRequest banUserRequest)
        {
            var date = DateTime.Now;
            var userid = Guid.Parse(banUserRequest.UserUuid);
            var adminid = Guid.Parse(banUserRequest.AdminUuid);
            var result = await _authenticationRepository.BanUser(userid, banUserRequest.BanReason, date, adminid);
            if (result)
                return new BanUserResponse
                {
                    Success = true,
                    Message = "User has been banned"
                };

            return new BanUserResponse
            {
                Success = false,
                Message = "User could not be banned"
            };
        }

        public Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            //TODO: will implement this after email service is implemented
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> LoginUser(LoginRequest loginRequest, string? refreshToken)
        {
            CheckIfUserExists(loginRequest.Email);
            var user = await _authenticationRepository.GetUser(loginRequest.Email);
            var comparison = CypherService.Compare(loginRequest.Password, user!.Passwordhash);
            if (!comparison)
                throw new Exception("Invalid password");
            var tokenDetails = new TokenDetails
            {
                Email = user.Email,
                Role = user.RoleId,
                RoleName = user.Role!.RoleName,
                Useruuid = user.Useruuid
            };
            var tokens = _tokenService.GenerateToken(tokenDetails);
            var expiresIn = tokens.Expiry.Subtract(DateTime.UtcNow).TotalSeconds;

            return new LoginResponse
            {
                AccessToken = tokens.RefreshToken,
                ExpiresIn = (long)expiresIn,
                RefreshToken = string.IsNullOrEmpty(refreshToken) ? tokens.RefreshToken : refreshToken,  
            };
        }

        public async Task<LoginResponse> LoginUser(RefreshTokenRequest refreshTokenRequest)
        {
            var refreshToken = refreshTokenRequest.RefreshToken;

            // Refresh token'ın geçerliliğini kontrol et
            var refreshTokenIsValid = _tokenService.ValidateToken(refreshToken);
            if (refreshTokenIsValid == false)
            {
                throw new Exception("Invalid refresh token");
            }

            var tokenDetails = _tokenService.RefreshToken(refreshToken);
            var user = await  _authenticationRepository.GetUser(tokenDetails.Email!);

            return await LoginUser(new LoginRequest
            {
                Email = user!.Email,
                Password = user.Passwordhash
            }, refreshToken);

        }

        public async Task<RegisterResponse> RegisterUser(RegisterRequest registerRequest)
        {
            CheckIfUserExists(registerRequest.Email);

            var user = new Auth
            {
                Email = registerRequest.Email,
                Passwordhash = CypherService.Encrypt(registerRequest.Password),
                Useruuid = Guid.NewGuid()
            };

            var result = await _authenticationRepository.AddUser(user);
            if (result)
                return new RegisterResponse
                {
                    Success = true,
                    Message = "User has been registered"
                };
            return new RegisterResponse
            {
                Success = false,
                Message = "User could not be registered"
            };
        }

        public async Task<UnbanUserResponse> UnbanUser(UnbanUserRequest unbanUserRequest)
        {
            var userid = Guid.Parse(unbanUserRequest.UserUuid);
            CheckIfUserExists(userid);

            var result = await _authenticationRepository.UnbanUser(userid);
            if(result)
                return new UnbanUserResponse
                {
                    Success = true,
                    Message = "User has been unbanned"
                };
            return new UnbanUserResponse
            {
                Success = false,
                Message = "User could not be unbanned"
            };

        }

        private async void CheckIfUserExists(Guid userUuid)
        {
            var ifUserExists = await _authenticationRepository.UserExists(userUuid);
            if (!ifUserExists)
                throw new Exception("User does not exist");
        }

        private async void CheckIfUserExists(string email)
        {
            var ifUserExists = await _authenticationRepository.UserExists(email);
            if (!ifUserExists)
                throw new Exception("User does not exist");
        }
    }
}
