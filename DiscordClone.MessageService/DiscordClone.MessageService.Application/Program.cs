using DiscordClone.MessageService.Application.Services;
using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.DataAccess.Repositories;
using DiscordClone.MessageService.Domain.Models;
using DiscordClone.MessageService.Infrastructure;
using DiscordClone.MessageService.Service.Contracts;
using DiscordClone.MessageService.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddSingleton(new MessageContext("172.23.32.1", 9042, "discord"));
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
