using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.Domain.Models;
using DiscordClone.MessageService.Service.Contracts;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.Service.Services
{
    public class MessageService(IMessageRepository messageRepository) : IMessageService
    {
        private readonly IMessageRepository _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await _messageRepository.GetMessages();
        }

        public async Task<Message> GetMessage(Guid messageId)
        {
            var ifExists = await _messageRepository.MessageExists(messageId);
            if (!ifExists)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Message with ID {messageId} not found."));
            }
            var message = await _messageRepository.Get(messageId);
            return message!;
        }

        public async Task<Message> AddMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            message.MessageId = Guid.NewGuid();
            message.UpdatedAt = message.CreatedAt;
            await _messageRepository.Add(message);
            return message;
        }

        public async Task<Message?> UpdateMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            var ifExists = await _messageRepository.MessageExists(message.MessageId);
            if (!ifExists)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Message with ID {message.MessageId} not found."));
            }
            var existingMessage = await _messageRepository.Get(message.MessageId) ?? throw new RpcException(new Status(StatusCode.NotFound, $"Message with ID {message.MessageId} not found."));
            existingMessage.Content = message.Content;
            existingMessage.UpdatedAt = DateTime.UtcNow;
            await _messageRepository.Update(existingMessage);
            return existingMessage;
        }

        public async Task<bool> DeleteMessage(Guid messageId)
        {
            var isExists = await _messageRepository.MessageExists(messageId);
            if (!isExists)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Message with ID {messageId} not found."));
            }
            await _messageRepository.Delete(messageId);
            return true;
        }

        public async Task<IEnumerable<Message>> GetMessagesByUser(Guid userId)
        {
            return await _messageRepository.GetByUser(userId);
        }

        public async Task<IEnumerable<Message>> GetMessagesByChannel(Guid channelId)
        {
            return await _messageRepository.GetByChannel(channelId);
        }

        public async Task<IEnumerable<Message>> GetMessagesByChannelAndTimeRange(Guid channelId, DateTime startTime, DateTime endTime)
        {
            return await _messageRepository.GetByChannel(channelId, startTime, endTime);
        }
    }
}
