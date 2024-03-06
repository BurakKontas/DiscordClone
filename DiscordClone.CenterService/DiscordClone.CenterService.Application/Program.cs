using DiscordClone.CenterService.Application.Behaviors;
using DiscordClone.CenterService.Infrastructure;
using DiscordClone.CenterService.Service.Contracts;
using DiscordClone.CenterService.Service.Services;
using MediatR;
using Serilog;

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
builder.Services.AddScoped<IMessageService, CenterService>();

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
