﻿using DiscordClone.MessageService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.DataAccess.Contracts
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessages();
        Task<Message?> Add(Message message);
        Task<Message?> Delete(Guid messageId);
        Task<Message?> Update(Message message);
        Task<Message?> Get(Guid messageId);
        Task<IEnumerable<Message>> GetByUser(Guid userId);
        Task<IEnumerable<Message>> GetByChannel(Guid channelId);
        Task<IEnumerable<Message>> GetByChannel(Guid channelId, DateTime startTime, DateTime endTime);
    }
}
