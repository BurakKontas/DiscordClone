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
            var ban = new Ban
            {
                Useruuid = Guid.Parse(banUserRequest.UserUuid),
                BanReason = banUserRequest.BanReason,
                BanDate = DateTime.Now,
                Adminuuid = Guid.Parse(banUserRequest.AdminUuid)
            };
            var result = await _authenticationRepository.BanUser(ban);
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
            await CheckIfUserExists(loginRequest.Email, true);
            var user = await _authenticationRepository.GetUser(loginRequest.Email);
            var comparison = CypherService.Compare(loginRequest.Password, user!.Passwordhash);
            if (!comparison)
                throw new Exception("Invalid password");
            await CheckIfUserBanned(user.Useruuid);
            var tokenDetails = new TokenDetails
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role!.RoleName,
                RoleId = user.RoleId,
                Useruuid = user.Useruuid
            };
            var tokens = _tokenService.GenerateToken(tokenDetails);
            var expiresIn = tokens.Expiry.Subtract(DateTime.UtcNow).TotalSeconds;
            user.LastLogin = DateTime.Now;
            await _authenticationRepository.UpdateUser(user);

            return new LoginResponse
            {
                AccessToken = tokens.Token,
                ExpiresIn = (int)expiresIn,
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
            await CheckIfUserExists(tokenDetails.Email!, true);
            await CheckIfUserBanned((Guid)tokenDetails.Useruuid!);
            var user = await _authenticationRepository.GetUser(tokenDetails.Email!);
            user!.LastLogin = DateTime.Now;
            await _authenticationRepository.UpdateUser(user);

            return await LoginUser(new LoginRequest
            {
                Email = user!.Email,
                Password = user.Passwordhash
            }, refreshToken);

        }

        public async Task<RegisterResponse> RegisterUser(RegisterRequest registerRequest)
        {
            await CheckIfUserExists(registerRequest.Email, false);

            var userRole = await _authenticationRepository.GetRole("user");
            var user = new Auth
            {
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                Passwordhash = CypherService.Encrypt(registerRequest.Password),
                Useruuid = Guid.NewGuid(),
                RoleId = userRole!.Id,
                LastLogin = DateTime.Now
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
            await CheckIfUserExists(userid, true);

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

        private async Task CheckIfUserExists(Guid userUuid, bool wannabeExist)
        {
            var ifUserExists = await _authenticationRepository.UserExists(userUuid);
            if (!ifUserExists)
                if(wannabeExist) throw new Exception("User does not exist");
        }

        private async Task CheckIfUserExists(string email, bool wannabeExist)
        {
            var ifUserExists = await _authenticationRepository.UserExists(email);
            if (!ifUserExists)
                if(wannabeExist) throw new Exception("User does not exist");
        }

        private async Task CheckIfUserBanned(Guid userUuid)
        {
            var user = await _authenticationRepository.GetUser(userUuid);
            if (user!.Banned == true)
                throw new Exception("User is banned");
        }
    }
}
