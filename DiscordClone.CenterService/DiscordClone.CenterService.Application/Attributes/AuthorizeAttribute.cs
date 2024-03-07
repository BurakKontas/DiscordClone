using System.Security.Claims;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Service.Adapters;
using DiscordClone.CenterService.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace DiscordClone.CenterService.Application.Attributes;
public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute(int level) : base(typeof(AuthorizeAuthorize))
    {
        Arguments = [level.ToString()];
    }
};

public class AuthorizeAuthorize(string level, IAuthenticationService authenticationService) : IAuthorizationFilter
{
    private readonly int _level = Int32.Parse(level);

    private readonly IAuthenticationService _authenticationService = authenticationService;

    private async Task<bool> CheckIfTokenValid(string token)
    {
        var ifAuthorized = await _authenticationService.ValidateTokenAsync(new TokenValidationRequest
        {
            Token = token
        });
        if (!ifAuthorized.IsValid) return false;
        return true;
    }

    private async Task<ExtractTokenResponse> ExtractToken(string token)
    {
        var tokenData = await _authenticationService.ExtractTokenAsync(new ExtractTokenRequest
        {
            Token = token
        });

        return tokenData;
    }

    private bool CheckIfAuthorized(int level)
    {
        if (level < _level) return false;
        return true;
    }

    // "403 Forbidden": Erişim yetkisi yok; "401 Unauthorized": Doğrulama gerekiyor.
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var token = context.HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split("Bearer ")[1];
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var ifValid = CheckIfTokenValid(token).Result;
        if (!ifValid)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var tokenData = ExtractToken(token).Result;
        var ifAuthorized = CheckIfAuthorized(tokenData.RoleId);
        if (!ifAuthorized)
        {
            context.Result = new ForbidResult();
            return;
        }

        //make user authorized
        var identity = new ClaimsIdentity(
            new List<Claim>
            {
                new("Level", tokenData.RoleId.ToString(), ClaimValueTypes.Integer),
                new(ClaimTypes.Role, tokenData.Role.ToString(), ClaimValueTypes.String),
                new(ClaimTypes.NameIdentifier, tokenData.UserUuid.ToString(), ClaimValueTypes.String),
                new(ClaimTypes.Email, tokenData.Email, ClaimValueTypes.Email),
                new(ClaimTypes.Name, tokenData.Username, ClaimValueTypes.String),
                new(ClaimTypes.UserData, tokenData.ToTokenString(), "ExtractTokenResponse"),
            }, "AuthServer Bearer");
        context.HttpContext.User = new ClaimsPrincipal(identity);

        return;
    }
}