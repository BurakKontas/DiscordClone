using CenteralService.Domain;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenteralService.Infrastructure
{
    public class EmailContext
    {
        public EmailProtoService.EmailProtoServiceClient Client { get; set; }
        public EmailContext(IConfiguration configuration, HttpClient client)
        {
            var url = configuration.GetSection("Grpc:EmailService").Value;
            var channel = GrpcChannel.ForAddress(url!, new GrpcChannelOptions
            {
                HttpClient = client
            });
            Client = new EmailProtoService.EmailProtoServiceClient(channel);
        }
    }
}
