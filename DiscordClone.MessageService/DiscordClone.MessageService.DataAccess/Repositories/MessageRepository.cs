using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.Domain.Models;
using DiscordClone.MessageService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.DataAccess.Repositories
{
    public class MessageRepository(MessageContext context) : IMessageRepository
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

            var cql = $"INSERT INTO discord.messages (message_id, content, user_id, channel_id, created_at) VALUES ({message.MessageId}, '{message.Content}', {message.UserId}, {message.ChannelId}, '{message.CreatedAt}')";
            return await GetAndReturnMessage(cql);
        }

        public async Task<Message?> Delete(Guid messageId)
        {
            var cql = $"DELETE FROM discord.messages WHERE message_id = {messageId}";
            return await GetAndReturnMessage(cql);
        }

        public async Task<Message?> Update(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);

            var cql = $"UPDATE discord.messages SET content = '{message.Content}' WHERE message_id = {message.MessageId}";
            return await GetAndReturnMessage(cql);
        }

        public async Task<Message?> Get(Guid messageId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE message_id = {messageId}";
            return await GetAndReturnMessage(cql);
        }

        public async Task<IEnumerable<Message>> GetByUser(Guid userId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE user_id = {userId}";
            return await GetAndReturnMessages(cql);
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId)
        {
            var cql = $"SELECT * FROM discord.messages WHERE channel_id = {channelId}";
            return await GetAndReturnMessages(cql);
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId, DateTime startTime, DateTime endTime)
        {
            var cql = $"SELECT * FROM discord.messages WHERE channel_id = {channelId} AND created_at >= '{startTime}' AND created_at <= '{endTime}'";
            return await GetAndReturnMessages(cql);
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
