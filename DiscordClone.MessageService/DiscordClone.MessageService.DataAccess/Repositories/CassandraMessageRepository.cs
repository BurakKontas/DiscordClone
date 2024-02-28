using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.DataAccess.Helpers;
using DiscordClone.MessageService.Domain.Models;
using DiscordClone.MessageService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.DataAccess.Repositories
{
    public class CassandraMessageRepository(MessageContext context) : IMessageRepository
    {
        private readonly MessageContext _context = context;

        public async Task<IEnumerable<Message>> GetMessages()
        {
            var cql = "SELECT * FROM discord.messages";
            return await GetAndReturnMessages(cql);
        }

        public async Task<Message?> Add(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            var createdAt = CassandraHelpers.ConvertToCassandraTimestamp(message.CreatedAt);
            var updatedAt = CassandraHelpers.ConvertToCassandraTimestamp(message.CreatedAt);

            var cql = $"INSERT INTO discord.messages (message_id, content, user_id, channel_id, created_at, updated_at) VALUES ({message.MessageId}, '{message.Content}', {message.UserId}, {message.ChannelId}, '{createdAt}', '{updatedAt}')";
            return await GetAndReturnMessage(cql);
        }

        public async Task<bool> Delete(Guid messageId)
        {
            try
            {
                var cql = $"DELETE FROM discord.messages WHERE message_id = {messageId}";
                await GetAndReturnMessage(cql);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public async Task<Message?> Update(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);
            var updatedAt = CassandraHelpers.ConvertToCassandraTimestamp(DateTime.UtcNow);
            var cql = $"UPDATE discord.messages SET content = '{message.Content}', updated_at = '{updatedAt}' WHERE message_id = {message.MessageId}";
            return await GetAndReturnMessage(cql);
        }

        public async Task<Message?> Get(Guid messageId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE message_id = {messageId}";
            return await GetAndReturnMessage(cql);
        }

        public async Task<IEnumerable<Message>> GetByUser(Guid userId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE user_id = {userId} ALLOW FILTERING";
            return await GetAndReturnMessages(cql);
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE channel_id = {channelId} ALLOW FILTERING";
            return await GetAndReturnMessages(cql);
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId, DateTime startTime, DateTime endTime)
        {
            var startTimeString = CassandraHelpers.ConvertToCassandraTimestamp(startTime);
            var endTimeString = CassandraHelpers.ConvertToCassandraTimestamp(endTime);
            var cql = $"SELECT * FROM discord.messages WHERE channel_id = {channelId} AND created_at >= '{startTimeString}' AND created_at <= '{endTimeString}' ALLOW FILTERING";
            return await GetAndReturnMessages(cql);
        }

        public async Task<bool> MessageExists(Guid messageId)
        {
            var cql = $"SELECT COUNT(*) FROM discord.messages WHERE message_id = {messageId}";
            var result = await _context.ExecuteAsync(cql);
            var count = (int)result.FirstOrDefault()?.GetValue<long>(0)!;
            return count > 0;
        }

        private async Task<IEnumerable<Message>> GetAndReturnMessages(string cql)
        {
            var messages = await _context.ExecuteAsync(cql);
            return Message.FromCassandraRow(messages);
        }

        private async Task<Message?> GetAndReturnMessage(string cql)
        {
            var messages = await _context.ExecuteAsync(cql);
            return Message.FromCassandraRow(messages).FirstOrDefault();
        }
    }
}
