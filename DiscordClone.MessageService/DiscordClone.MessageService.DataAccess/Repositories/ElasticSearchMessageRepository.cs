using DiscordClone.MessageService.DataAccess.Contracts;
using DiscordClone.MessageService.Domain.Models;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.DataAccess.Repositories
{
    public class ElasticsearchMessageRepository : IMessageRepository
    {
        private readonly ElasticClient _client;
        private const string IndexName = "messages"; // Elasticsearch'te kullanmak için index adı

        public ElasticsearchMessageRepository(IConfiguration configuration)
        {
            var section = configuration.GetSection("ElasticSearch");
            var url = section["URL"];
            var username = section["Username"];
            var password = section["Password"];
            var fingerprint = section["Fingerprint"];

            var settings = new ConnectionSettings(new Uri(url!))
                .DefaultIndex(IndexName)
                .EnableApiVersioningHeader()
                .CertificateFingerprint(fingerprint)
                .BasicAuthentication(username, password);
            _client = new ElasticClient(settings);
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            var response = await _client.SearchAsync<Message>(s => s
                .MatchAll()
                .Index(IndexName)
            );
            if(response.IsValid)
            {
                return response.Documents;
            } 
            else
            {
                throw new Exception("An error occured during getmessages elasticsearch.");
            }
        }

        public async Task<Message?> Add(Message message)
        {
            var response = await _client.IndexDocumentAsync(message);
            if (response.IsValid)
            {
                return message;
            }
            return null;
        }

        public async Task<bool> Delete(Guid messageId)
        {
            var response = await _client.DeleteByQueryAsync<Message>(d => d
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.MessageId)
                        .Query(messageId.ToString())
                    )
                )
                .Index(IndexName)
            );
            if (response.Deleted > 0) return true;
            else return false;
        }

        public async Task<Message?> Update(Message message)
        {
            var response = await _client.UpdateAsync<Message>(message.MessageId, u => u
                .Index(IndexName)
                .DocAsUpsert(true)
                .Doc(message)
            );
            if (response.IsValid)
            {
                return message;
            }
            return null;
        }

        public async Task<Message?> Get(Guid messageId)
        {
            var response = await _client.SearchAsync<Message>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.MessageId)
                        .Query(messageId.ToString())
                    )
                )
                .Index(IndexName)
            );
            if (response.Documents.Count > 0) return response.Documents.FirstOrDefault();
            return null;
        }

        public async Task<IEnumerable<Message>> GetByUser(Guid userId)
        {
            var response = await _client.SearchAsync<Message>(s => s
                .Query(q => q
                    .Term(t => t.Field(f => f.UserId).Value(userId))
                )
                .Index(IndexName)
            );
            return response.Documents;
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId)
        {
            var response = await _client.SearchAsync<Message>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.ChannelId)
                        .Query(channelId.ToString())
                    )
                )
                .Index(IndexName)
            );
            return response.Documents;
        }

        public async Task<IEnumerable<Message>> GetByChannel(Guid channelId, DateTime startTime, DateTime endTime)
        {
            var response = await _client.SearchAsync<Message>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .Match(m => m
                                .Field(f => f.ChannelId)
                                .Query(channelId.ToString())
                            ),
                            mu => mu
                            .DateRange(dr => dr
                                .Field(f => f.CreatedAt)
                                .GreaterThanOrEquals(startTime)
                                .LessThanOrEquals(endTime)
                            )
                        )
                    )
                )
                .Index(IndexName)
            );
            return response.Documents;
        }

        public async Task<bool> MessageExists(Guid messageId)
        {
            var document = await Get(messageId);
            return document != null;
        }
    }
}
