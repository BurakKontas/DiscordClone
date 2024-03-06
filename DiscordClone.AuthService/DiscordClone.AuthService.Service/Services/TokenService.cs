using DiscordClone.AuthService.Domain.Models;
using DiscordClone.AuthService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace DiscordClone.AuthService.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryMinutes;
        private readonly int _refreshTokenExpiryMinutes;

        public TokenService(IConfiguration configuration)
        {
            var section = configuration.GetSection("Jwt");
            _secretKey = section["Jwt:SecretKey"]!;
            _issuer = section["Jwt:Issuer"]!;
            _audience = section["Jwt:Audience"]!;
            _expiryMinutes = int.Parse(section["Jwt:ExpiryMinutes"]!);
            _refreshTokenExpiryMinutes = int.Parse(section["Jwt:RefreshTokenExpiryMinutes"]!);
        }   

        private string GenerateTokens(TokenDetails tokenDetails, int expiryMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var claims = new List<Claim>();

            var properties = typeof(TokenDetails).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(tokenDetails)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    claims.Add(new Claim(property.Name, value));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public GenerateTokenMethodReturn GenerateToken(TokenDetails tokenDetails)
        {
            var token = GenerateTokens(tokenDetails, _expiryMinutes);
            var expiryDateTime = DateTime.UtcNow.AddMinutes(_expiryMinutes);

            return new GenerateTokenMethodReturn
            {
                Token = token,
                Expiry = expiryDateTime,
                RefreshToken = GenerateRefreshToken(tokenDetails),
                RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(_refreshTokenExpiryMinutes)
            };
        }

        public string GenerateRefreshToken(TokenDetails tokenDetails)
        {
            return GenerateTokens(tokenDetails, _refreshTokenExpiryMinutes);
        }

        public string? GetEmailFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            return jwtToken?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        public string? GetRoleFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            return jwtToken?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }

        public TokenDetails RefreshToken(string token)
        {
            var tokenDetails = DecodeToken(token);
            return tokenDetails;
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _issuer,
                    ValidateAudience = true,
                    ValidAudience = _audience,
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TokenDetails DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return ExtractTokenDetails((JwtSecurityToken)validatedToken);
            }
            catch (Exception ex)
            {
                // Token validation failed
                throw new Exception("Token validation failed", ex);
            }
        }

        private TokenDetails ExtractTokenDetails(JwtSecurityToken jwtToken)
        {
            return new TokenDetails
            {
                Email = jwtToken.Claims.FirstOrDefault(x => x.Type == "Email")?.Value,
                Role = Int32.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "Role")!.Value),
                RoleName = jwtToken.Claims.FirstOrDefault(x => x.Type == "RoleName")?.Value,
                Useruuid = Guid.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "Useruuid")!.Value)
            };
        }
    }
}
