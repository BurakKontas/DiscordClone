
using DiscordClone.AuthService.Application.Controllers;
using DiscordClone.AuthService.DataAccess.Contracts;
using DiscordClone.AuthService.DataAccess.Repositories;
using DiscordClone.AuthService.Infrastructure;
using DiscordClone.AuthService.Service.Contracts;
using DiscordClone.AuthService.Service.Services;
using DiscordClone.MessageService.Application.Behaviors;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>));
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AuthenticationController>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
