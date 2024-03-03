﻿using DiscordClone.AuthService.Application.Queries;
using DiscordClone.AuthService.Service;
using Grpc.Core;
using MediatR;

namespace DiscordClone.AuthService.Application.Controllers
{
    public class AuthenticationController(IMediator mediator): AuthenticationProtoService.AuthenticationProtoServiceBase
    {
        private readonly IMediator _mediator = mediator;

        public override async Task<TokenResponse> GenerateToken(TokenRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GenerateTokenQuery(request));
        }

        public override async Task<TokenValidationResponse> ValidateToken(TokenValidationRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new ValidateTokenQuery(request));
        }

        public override async Task<TokenResponse> RefreshToken(RefreshTokenRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new RefreshTokenQuery(request));
        }

        public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new LoginQuery(request));
        }

        public override async Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new RegisterQuery(request));
        }

        public override async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new ForgotPasswordQuery(request));
        }
    }
}
