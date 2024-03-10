using EmailService.Application.Behaviors;
using EmailService.Application.Controllers;
using EmailService.DataAccess.Contracts;
using EmailService.DataAccess.Repositories;
using EmailService.Infrastructure;
using EmailService.Service.Contracts;
using EmailService.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddScoped<EmailContext>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IEmailService, EmailService.Services.EmailService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>));

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.WithOrigins("localhost", "::1", "127.0.0.1");
});

// Configure the HTTP request pipeline.
app.MapGrpcService<EmailController>().RequireCors();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapDefaultEndpoints();

app.Run();
