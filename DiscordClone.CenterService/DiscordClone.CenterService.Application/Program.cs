using DiscordClone.CenterService.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/loadbalancer.log", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://172.23.32.1:5341", apiKey: "33YqEQApCZ50n63v4TCX")
    .CreateLogger();

// Add services to the container.
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddScoped<MessageContext>();

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
