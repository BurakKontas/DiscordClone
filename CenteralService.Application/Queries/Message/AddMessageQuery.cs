using CenteralService.Domain;
using CenteralService.Infrastructure;
using MediatR;

namespace CenteralService.Application.Queries.Message
{
    public record AddMessageQuery(AddMessageRequest Request) : IRequest<AddMessageReply>;
}
