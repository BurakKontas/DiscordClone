﻿using AuthService.Domain;
using AuthService.Service;
using MediatR;

namespace AuthService.Application.Queries
{
    public record BanUserQuery(BanUserRequest request) : IRequest<BanUserResponse>;
}
