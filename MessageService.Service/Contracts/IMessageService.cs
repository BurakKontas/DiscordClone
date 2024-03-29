﻿using MessageService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageService.Service.Contracts
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessages();

        Task<Message> GetMessage(Guid messageId);

        Task<Message> AddMessage(Message message);

        Task<Message?> UpdateMessage(Message message);

        Task<bool> DeleteMessage(Guid messageId);

        Task<IEnumerable<Message>> GetMessagesByUser(Guid userId);

        Task<IEnumerable<Message>> GetMessagesByChannel(Guid channelId);

        Task<IEnumerable<Message>> GetMessagesByChannelAndTimeRange(Guid channelId, DateTime startTime, DateTime endTime);

    }
}
