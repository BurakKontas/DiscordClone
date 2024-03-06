using DiscordClone.AuthService.Domain;
using DiscordClone.AuthService.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.AuthService.Service.Contracts
{
    public interface ITokenService
    {
        public GenerateTokenMethodReturn GenerateToken(TokenDetails tokenDetails);
        public string GenerateRefreshToken(TokenDetails tokenDetails);
        public bool ValidateToken(string token);
        public string? GetRoleFromToken(string token);
        public string? GetEmailFromToken(string token);
        public TokenDetails RefreshToken(string token);
        public TokenDetails ExtractToken(JwtSecurityToken jwtToken);
    }
}
