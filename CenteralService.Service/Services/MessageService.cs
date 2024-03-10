using CenteralService.Domain;
using CenteralService.Infrastructure;
using CenteralService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenteralService.Service.Services
{
    public class MessageService(MessageContext messageContext) : IMessageService
    {
        private readonly MessageContext _messageContext = messageContext;
        public async Task<AddMessageReply> AddMessageAsync(AddMessageRequest request)
        {
            var reply = await _messageContext.Client.AddMessageAsync(request);
            return reply;
        }

        public async Task<GetMessagesReply> GetMessagesAsync(GetMessagesRequest request)
        {
            var reply = await _messageContext.Client.GetMessagesAsync(request);
            return reply;
        }

        public async Task<GetMessageReply> GetMessageAsync(GetMessageRequest request)
        {
            var reply = await _messageContext.Client.GetMessageAsync(request);
            return reply;
        }

        public async Task<UpdateMessageReply> UpdateMessageAsync(UpdateMessageRequest request)
        {
            var reply = await _messageContext.Client.UpdateMessageAsync(request);
            return reply;
        }

        public async Task<DeleteMessageReply> DeleteMessageAsync(DeleteMessageRequest request)
        {
            var reply = await _messageContext.Client.DeleteMessageAsync(request);
            return reply;
        }

        public async Task<GetMessagesByChannelReply> GetMessagesByChannelAsync(GetMessagesByChannelRequest request)
        {
            var reply = await _messageContext.Client.GetMessagesByChannelAsync(request);
            return reply;
        }

        public async Task<GetMessagesByUserReply> GetMessagesByUserAsync(GetMessagesByUserRequest request)
        {
            var reply = await _messageContext.Client.GetMessagesByUserAsync(request);
            return reply;
        }

        public async Task<GetMessagesByChannelAndTimeRangeReply> GetMessagesByDateAsync(GetMessagesByChannelAndTimeRangeRequest request)
        {
            var reply = await _messageContext.Client.GetMessagesByChannelAndTimeRangeAsync(request);
            return reply;
        }
    }
}
