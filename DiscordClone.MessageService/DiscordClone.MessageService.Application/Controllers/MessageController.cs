using DiscordClone.MessageService.Application.Queries;
using DiscordClone.MessageService.Domain;
using Grpc.Core;
using MediatR;

namespace DiscordClone.MessageService.Application.Controllers
{
    public class MessageController(IMediator mediator) : MessageProtoService.MessageProtoServiceBase
    {
        private readonly IMediator _mediator = mediator;

        public override async Task<AddMessageReply> AddMessage(AddMessageRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new AddMessageQuery(request));
        }

        public override async Task<GetMessageReply> GetMessage(GetMessageRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GetMessageQuery(request));
        }

        public override async Task<GetMessagesReply> GetMessages(GetMessagesRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GetMessagesQuery(request));
        }

        public override async Task<UpdateMessageReply> UpdateMessage(UpdateMessageRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new UpdateMessageQuery(request));
        }

        public override async Task<DeleteMessageReply> DeleteMessage(DeleteMessageRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new DeleteMessageQuery(request));
        }

        public override async Task<GetMessagesByUserReply> GetMessagesByUser(GetMessagesByUserRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GetMessagesByUserQuery(request));
        }

        public override async Task<GetMessagesByChannelReply> GetMessagesByChannel(GetMessagesByChannelRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GetMessagesByChannelQuery(request));
        }

        public override async Task<GetMessagesByChannelAndTimeRangeReply> GetMessagesByChannelAndTimeRange(GetMessagesByChannelAndTimeRangeRequest request, ServerCallContext context)
        {
            return await _mediator.Send(new GetMessagesByChannelAndTimeRangeQuery(request));
        }
    }
}
