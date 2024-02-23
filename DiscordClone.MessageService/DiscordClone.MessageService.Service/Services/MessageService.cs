using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.Domain.Models;
using DiscordClone.MessageService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var message = await _messageRepository.Get(messageId);
            return message == null ? throw new KeyNotFoundException($"Message with ID {messageId} not found.") : message;
        }

        public async Task<Message?> AddMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            return await _messageRepository.Add(message);
        }

        public async Task<Message?> UpdateMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            var existingMessage = await _messageRepository.Get(message.MessageId) ?? throw new KeyNotFoundException($"Message with ID {message.MessageId} not found.");
            existingMessage.Content = message.Content;
            return await _messageRepository.Update(existingMessage);
        }

        public async Task DeleteMessage(Guid messageId)
        {
            var existingMessage = await _messageRepository.Get(messageId) ?? throw new KeyNotFoundException($"Message with ID {messageId} not found.");
            await _messageRepository.Delete(messageId);
        }

        public async Task<IEnumerable<Message?>> GetMessagesByUser(Guid userId)
        {
            return await _messageRepository.GetByUser(userId);
        }

        public async Task<IEnumerable<Message?>> GetMessagesByChannel(Guid channelId)
        {
            return await _messageRepository.GetByChannel(channelId);
        }

        public async Task<IEnumerable<Message?>> GetMessagesByChannelAndTimeRange(Guid channelId, DateTime startTime, DateTime endTime)
        {
            return await _messageRepository.GetByChannel(channelId, startTime, endTime);
        }

    }
}
