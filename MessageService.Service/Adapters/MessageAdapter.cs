using MessageService.Domain;
using MessageService.Domain.Models;

namespace MessageService.Service.Adapters
{
    public static class MessageAdapter
    {
        public static MessageProto ToMessageProto(this Message message)
        {
            return new MessageProto
            {
                MessageId = message.MessageId.ToString(),
                UserId = message.UserId.ToString(),
                ChannelId = message.ChannelId.ToString(),
                Content = message.Content,
                CreatedAt = message.CreatedAt.ToString(),
                UpdatedAt = message.UpdatedAt.ToString()
            };
        }

        public static Message ToMessage(this MessageProto messageProto)
        {
            return new Message
            {
                MessageId = Guid.Parse(messageProto.MessageId),
                UserId = Guid.Parse(messageProto.UserId),
                ChannelId = Guid.Parse(messageProto.ChannelId),
                Content = messageProto.Content,
                CreatedAt = DateTime.Parse(messageProto.CreatedAt),
                UpdatedAt = DateTime.Parse(messageProto.UpdatedAt)
            };
        }

        public static Message ToMessage(this AddMessageRequest request)
        {
            return new Message
            {
                UserId = Guid.Parse(request.UserId),
                ChannelId = Guid.Parse(request.ChannelId),
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Message ToMessage(this UpdateMessageRequest request)
        {

            return new Message
            {
                MessageId = Guid.Parse(request.MessageId),
                UserId = Guid.Parse(request.UserId),
                Content = request.Content,
            };
        }

        public static IEnumerable<MessageProto> ToMessageProtos(this IEnumerable<Message> messages)
        {
            return messages.Select(m => m.ToMessageProto());
        }

        public static IEnumerable<Message> ToMessages(this IEnumerable<MessageProto> messageProtos)
        {
            return messageProtos.Select(m => m.ToMessage());
        }
    }
}
