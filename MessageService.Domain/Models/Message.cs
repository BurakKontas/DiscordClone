using Cassandra;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MessageService.Domain.Models
{
    public class Message
    {
        [BsonId]
        public Guid MessageId { get; set; }
        public string? Content { get; set; }
        public Guid UserId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"MessageId: {MessageId}, Content: {Content}, UserId: {UserId}, ChannelId: {ChannelId}, CreatedAt: {CreatedAt}";
        }

        public static Message FromCassandraRow(Row row)
        {
            return new Message
            {
                MessageId = row.GetValue<Guid>("message_id"),
                Content = row.GetValue<string>("content"),
                UserId = row.GetValue<Guid>("user_id"),
                ChannelId = row.GetValue<Guid>("channel_id"),
                CreatedAt = row.GetValue<DateTime>("created_at"),
                UpdatedAt = row.GetValue<DateTime?>("updated_at")
            };
        }

        public static IEnumerable<Message> FromCassandraRow(RowSet rows)
        {
            return rows.Select(FromCassandraRow);
        }
    }
}
