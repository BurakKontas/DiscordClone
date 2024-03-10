using CenteralService.Application.Behaviors;
using CenteralService.Application.Controllers.gRPC;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using CenteralService.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var ports = builder.Configuration["ASPNETCORE_URLS"]!.Split(";").Select(x => new Uri(x)).ToList();
var https_port = ports[^2].Port;
var http_port = ports[^1].Port;
var grpc_port = int.Parse(builder.Configuration["ASPNETCORE_GRPC_PORT"]!);

builder.WebHost.UseKestrel((context, options) =>
{
    options.ListenAnyIP(http_port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });

    options.ListenAnyIP(https_port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
        listenOptions.UseHttps();
    });

    options.ListenAnyIP(grpc_port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
        listenOptions.UseHttps(); //use this to enable TLS
    });
});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

// Add services to the container.
builder.Services.AddScoped<MessageContext>();
builder.Services.AddScoped<AuthContext>();
builder.Services.AddScoped<EmailContext>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingAndLoggingBehavior<,>));
builder.Services.AddControllers();

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");
builder.Services.AddSingleton(logger);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var auth_url = builder.Configuration["Grpc:AuthenticationService"] ?? throw new Exception("Grpc:AuthenticationService is not set");
var message_url = builder.Configuration["Grpc:MessageService"] ?? throw new Exception("Grpc:MessageService is not set");
var email_url = builder.Configuration["Grpc:EmailService"] ?? throw new Exception("Grpc:EmailService is not set");

builder.Services.AddHttpClient<AuthContext>(client => client.BaseAddress = new Uri(auth_url));
builder.Services.AddHttpClient<MessageContext>(client => client.BaseAddress = new Uri(message_url));
builder.Services.AddHttpClient<EmailContext>(client => client.BaseAddress = new Uri(email_url));

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

app.MapDefaultEndpoints();

app.MapGrpcService<MessageProtoController>();
app.MapGrpcService<AuthProtoController>();
app.MapGrpcService<EmailProtoController>();

app.MapGrpcReflectionService();

app.Run();
