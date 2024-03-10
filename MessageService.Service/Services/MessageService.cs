using MessageService.Domain.Models;
using MessageService.Service.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageService(IMongoClient client)
        {
            var database = client.GetDatabase("message_mongodb");
            _messages = database.GetCollection<Message>("Messages");
        }

        public async Task<Message> AddMessage(Message message)
        {
            await _messages.InsertOneAsync(message);
            return message;
        }

        public async Task<bool> DeleteMessage(Guid messageId)
        {
            var result = await _messages.DeleteOneAsync(m => m.MessageId == messageId);
            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await _messages.Find(_ => true).ToListAsync();
        }

        public async Task<Message> GetMessage(Guid messageId)
        {
            return await _messages.Find(m => m.MessageId == messageId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByChannel(Guid channelId)
        {
            return await _messages.Find(m => m.ChannelId == channelId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByChannelAndTimeRange(Guid channelId, DateTime startTime, DateTime endTime)
        {
            var filter = Builders<Message>.Filter.And(
                Builders<Message>.Filter.Eq(m => m.ChannelId, channelId),
                Builders<Message>.Filter.Gte(m => m.CreatedAt, startTime),
                Builders<Message>.Filter.Lte(m => m.CreatedAt, endTime)
            );

            return await _messages.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByUser(Guid userId)
        {
            return await _messages.Find(m => m.UserId == userId).ToListAsync();
        }

        public async Task<Message?> UpdateMessage(Message message)
        {
            var result = await _messages.ReplaceOneAsync(m => m.MessageId == message.MessageId, message);
            return result.IsAcknowledged ? message : null;
        }
    }
}
