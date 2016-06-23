using Nest;
using Newtonsoft.Json;
using Sixeyed.BadApi.Indexer.Model;
using Sixeyed.BadApi.Model;
using StackExchange.Redis;
using System;

namespace Sixeyed.BadApi.Indexer
{
    public class Program
    {
        private static ConnectionMultiplexer _Multiplexer;
        private static readonly ElasticClient _Client;
        static Program()
        {
            _Multiplexer = ConnectionMultiplexer.Connect("redis");

            var node = new Uri("http://elasticsearch:9200");
            var settings = new ConnectionSettings(node);
            _Client = new ElasticClient(settings);
            CreateIndex();
        }

        private static void CreateIndex()
        {
            var descriptor = new CreateIndexDescriptor("api-responses")
                                 .Mappings(ms => ms.Map<ApiResponseDocument>(m => m.AutoMap()));

            _Client.CreateIndex(descriptor);
        }

        public static void Main(string[] args)
        {
            var subscriber = _Multiplexer.GetSubscriber();
            subscriber.Subscribe("api-responses", IndexResponse);
            Console.ReadLine();
        }

        private static void IndexResponse(RedisChannel channel, RedisValue value)
        {
            var response = JsonConvert.DeserializeObject<ApiResponse>((string)value);
            var document = new ApiResponseDocument
            {
                Id = Guid.NewGuid().ToString(),
                IndexWorker = Environment.MachineName,
                ProcessedTimestamp = DateTime.Now,
                StatusCode = response.StatusCode,
                SentTimestamp = response.Timestamp,
                WebServer = response.Server
            };

            _Client.Index(document, d => d.Index("api-responses").Id(document.Id));

            Console.WriteLine($"Indexed document with id: {document.Id}");
        }
    }
}