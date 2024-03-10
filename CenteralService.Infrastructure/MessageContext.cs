using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Core.Interceptors;
using CenteralService.Domain;
using Microsoft.Extensions.Configuration;



namespace CenteralService.Infrastructure
{
    public class MessageContext
    {
        public MessageProtoService.MessageProtoServiceClient Client { get; set; }
        public MessageContext(IConfiguration configuration, HttpClient client)
        {
            var url = configuration.GetSection("Grpc:MessageService").Value;
            var channel = GrpcChannel.ForAddress(url!, new GrpcChannelOptions
            {
                HttpClient = client
            });
            Client = new MessageProtoService.MessageProtoServiceClient(channel);
        }
    }
}
