using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Core.Interceptors;



namespace DiscordClone.CenterService.Infrastructure
{
    public class MessageContext
    {
        public MessageProtoService.MessageProtoServiceClient Client { get; set; }
        public MessageContext()
        {
            var channel = GrpcChannel.ForAddress("http://172.23.32.1:32773/");
            Client = new MessageProtoService.MessageProtoServiceClient(channel);
        }
    }
}
