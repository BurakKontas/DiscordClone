var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin()
                      .AddDatabase("Auth");

var message_mongodb = builder.AddMongoDB("message_mongodb");

var centeral = builder.AddProject<Projects.CenteralService_Application>("centeral")
                      .WithLaunchProfile("https")
                      .WithEndpoint(name: "ASPNETCORE_GRPC_PORT", hostPort: 5006, env: "ASPNETCORE_GRPC_PORT");

var auth = builder.AddProject<Projects.AuthService_Application>("authentication")
                  .AsHttp2Service()
                  .WithLaunchProfile("https")
                  .WithReference(postgres)
                  .WithReference(centeral);

var email = builder.AddProject<Projects.EmailService_Application>("email")
                   .AsHttp2Service()
                   .WithLaunchProfile("https")
                   .WithReference(centeral);

var message = builder.AddProject<Projects.MessageService_Application>("message")
                     .AsHttp2Service()
                     .WithLaunchProfile("https")
                     .WithReference(message_mongodb)
                     .WithReference(centeral);

centeral.WithReference(auth)
        .WithReference(email)
        .WithReference(message);


builder.Build().Run();
