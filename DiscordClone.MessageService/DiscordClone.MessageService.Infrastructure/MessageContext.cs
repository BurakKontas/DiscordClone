using Cassandra;
using DiscordClone.MessageService.Domain.Models;
using System;
using System.Diagnostics.Metrics;

namespace DiscordClone.MessageService.Infrastructure
{
    public class MessageContext : IDisposable
    {
        private readonly Cluster _cluster;
        private readonly ISession _session;

        public MessageContext(string contactPoint, int port, string keyspace)
        {
            if (string.IsNullOrWhiteSpace(contactPoint))
                throw new ArgumentNullException(nameof(contactPoint));

            if (string.IsNullOrWhiteSpace(keyspace))
                throw new ArgumentNullException(nameof(keyspace));

            _cluster = Cluster.Builder()
                             .AddContactPoint(contactPoint)
                             .WithPort(port)
                             .Build();

            try
            {
                _session = _cluster.Connect(keyspace);
            } 
            catch (Exception ex)
            {
                throw new Exception($"Error connecting to Cassandra: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _session?.Dispose();
            _cluster?.Dispose();
        }

        public RowSet Execute(string cql)
        {
            if (string.IsNullOrWhiteSpace(cql))
                throw new ArgumentNullException(nameof(cql));

            return _session.Execute(cql);
        }

        public async Task<RowSet> ExecuteAsync(string cql)
        {
            if (string.IsNullOrWhiteSpace(cql))
                throw new ArgumentNullException(nameof(cql));

            var statement = new SimpleStatement(cql);
            return await _session.ExecuteAsync(statement).ConfigureAwait(false);
        }
    }
}