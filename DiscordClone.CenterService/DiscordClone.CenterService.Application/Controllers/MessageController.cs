using DiscordClone.CenterService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DiscordClone.CenterService.Application.Queries.Message;
using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Application.Attributes;

namespace DiscordClone.CenterService.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize(1)]
        [HttpPost("addmessage")]
        public async Task<IActionResult> AddMessage(AddMessageRequest request)
        {
            var reply = await _mediator.Send(new AddMessageQuery(request));
            return Ok(reply);
        }

        [HttpGet("getmessages")]
        public async Task<IActionResult> GetMessages()
        {
            var reply = await _mediator.Send(new GetMessagesQuery(new() { }));
            return Ok(reply);
        }

        [HttpGet("getmessage")]
        public async Task<IActionResult> GetMessage(GetMessageRequest request)
        {
            var reply = await _mediator.Send(new GetMessageQuery(request));
            return Ok(reply);
        }

        [HttpPut("updatemessage")]
        public async Task<IActionResult> UpdateMessage(UpdateMessageRequest request)
        {
            var reply = await _mediator.Send(new UpdateMessageQuery(request));
            return Ok(reply);
        }

        [HttpDelete("deletemessage")]
        public async Task<IActionResult> DeleteMessage(DeleteMessageRequest request)
        {
            var reply = await _mediator.Send(new DeleteMessageQuery(request));
            return Ok(reply);
        }

        [HttpGet("getmessagesbychannel")]
        public async Task<IActionResult> GetMessagesByChannel(GetMessagesByChannelRequest request)
        {
            var reply = await _mediator.Send(new GetMessagesByChannelQuery(request));
            return Ok(reply);
        }

        [HttpGet("getmessagesbyuser")]
        public async Task<IActionResult> GetMessagesByUser(GetMessagesByUserRequest request)
        {
            var reply = await _mediator.Send(new GetMessagesByUserQuery(request));
            return Ok(reply);
        }

        [HttpGet("getmessagesbydate")]
        public async Task<IActionResult> GetMessagesByDate(GetMessagesByChannelAndTimeRangeRequest request)
        {
            var reply = await _mediator.Send(new GetMessagesByChannelAndTimeRangeQuery(request));
            return Ok(reply);
        }
    }
}
