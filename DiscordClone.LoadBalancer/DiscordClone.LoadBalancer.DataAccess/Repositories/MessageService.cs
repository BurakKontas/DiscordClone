using DiscordClone.LoadBalancer.DataAccess.Contracts;
using DiscordClone.LoadBalander.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.LoadBalancer.DataAccess.Repositories
{
    public class MessageService : IMessageService
    {
        public Task<HelloReply> SayHello()
        {
            throw new NotImplementedException();
        }
    }
}
