using DiscordClone.EmailService.Application.Behaviors;
using DiscordClone.EmailService.Application.Controllers;
using DiscordClone.EmailService.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<EmailContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<EmailController>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
