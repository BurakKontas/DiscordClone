using System;
using System.Threading.Tasks;
using DiscordClone.CenterService.Service.Contracts;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

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

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        return;
        context.Result = new ForbidResult();
    }
}