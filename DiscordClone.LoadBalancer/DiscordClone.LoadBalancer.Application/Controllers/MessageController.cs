using DiscordClone.LoadBalancer.Infrastructure;
using DiscordClone.LoadBalander.Infrastructure;
using DiscordClone.LoadBalaner.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscordClone.LoadBalancer.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController(
        MessageContext messageContext
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<Response<HelloReply>> Get()
        {
            try
            {
                var reply = await messageContext.Client.SayHelloAsync(new HelloRequest() { Name = "Arda" });
                return Response<HelloReply>.Success(reply);
            } catch (Exception ex)
            {
                return Response<HelloReply>.Fail(ex);
            }
        }
    }
}
