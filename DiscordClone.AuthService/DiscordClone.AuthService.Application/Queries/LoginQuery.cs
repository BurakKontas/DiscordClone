﻿using DiscordClone.AuthService.Service;
using MediatR;

namespace DiscordClone.AuthService.Application.Queries
{
    public record LoginQuery(LoginRequest Request): IRequest<LoginResponse>;
}