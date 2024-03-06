using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Core.Interceptors;
using DiscordClone.CenterService.Domain;
using Microsoft.Extensions.Configuration;



namespace DiscordClone.CenterService.Infrastructure
{
    public class AuthContext
    {
        public AuthenticationProtoService.AuthenticationProtoServiceClient Client { get; set; }
        public AuthContext(IConfiguration configuration)
        {
            var url = configuration.GetSection("Grpc:AuthenticationService").Value;
            var channel = GrpcChannel.ForAddress(url!);
            Client = new AuthenticationProtoService.AuthenticationProtoServiceClient(channel);
        }
    }
}
