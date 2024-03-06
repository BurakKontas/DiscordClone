using DiscordClone.CenterService.Application.Attributes;
using DiscordClone.CenterService.Application.Behaviors;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using DiscordClone.CenterService.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var loggerConfig = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/loadbalancer.log", rollingInterval: RollingInterval.Day);

var seqServerUrl = builder.Configuration["Logging:Seq:ServerUrl"];
var seqApiKey = builder.Configuration["Logging:Seq:ApiKey"];
if (!string.IsNullOrEmpty(seqServerUrl) && !string.IsNullOrEmpty(seqApiKey))
    loggerConfig.WriteTo.Seq(seqServerUrl, apiKey: seqApiKey);

Log.Logger = loggerConfig.CreateLogger();

// Add services to the container.
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddScoped<MessageContext>();
builder.Services.AddScoped<AuthContext>();
builder.Services.AddScoped<IMessageService, CenterService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingAndLoggingBehavior<,>));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
