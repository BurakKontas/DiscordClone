using DiscordClone.LoadBalander.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.LoadBalancer.DataAccess.Contracts
{
    public interface IMessageService
    {
        Task<HelloReply> SayHello();
    }
}
