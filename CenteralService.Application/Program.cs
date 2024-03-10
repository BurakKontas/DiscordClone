using CenteralService.Application.Behaviors;
using CenteralService.Application.Controllers.gRPC;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using CenteralService.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var urls = builder.Configuration["ASPNETCORE_URLS"]!.Split(";");
var http_port = new Uri(urls[^1]).Port;
var grpc_port = new Uri(urls[0]).Port;

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(http_port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
        //listenOptions.UseHttps();
    });

    options.ListenAnyIP(grpc_port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });

});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

// Add services to the container.
builder.Services.AddScoped<MessageContext>();
builder.Services.AddScoped<AuthContext>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
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

builder.Services.AddHttpClient<AuthContext>(client => client.BaseAddress = new Uri(auth_url));
builder.Services.AddHttpClient<MessageContext>(client => client.BaseAddress = new Uri(message_url));

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

app.MapGrpcService<MessageProtoController>(); // Örnek bir gRPC MessageService sınıfı
app.MapGrpcService<AuthProtoController>(); // Örnek bir gRPC AuthService sınıfı
app.MapGrpcReflectionService();

app.Run();
