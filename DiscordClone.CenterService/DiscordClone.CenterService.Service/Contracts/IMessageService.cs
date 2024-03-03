using DiscordClone.CenterService.Domain;
using DiscordClone.CenterService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.CenterService.Service.Contracts
{
    public interface IMessageService
    {
        Task<AddMessageReply> AddMessageAsync(AddMessageRequest request);
        Task<GetMessagesReply> GetMessagesAsync(GetMessagesRequest request);
        Task<GetMessageReply> GetMessageAsync(GetMessageRequest request);
        Task<UpdateMessageReply> UpdateMessageAsync(UpdateMessageRequest request);
        Task<DeleteMessageReply> DeleteMessageAsync(DeleteMessageRequest request);
        Task<GetMessagesByChannelReply> GetMessagesByChannelAsync(GetMessagesByChannelRequest request);
        Task<GetMessagesByUserReply> GetMessagesByUserAsync(GetMessagesByUserRequest request);
        Task<GetMessagesByChannelAndTimeRangeReply> GetMessagesByDateAsync(GetMessagesByChannelAndTimeRangeRequest request);
    }
}
