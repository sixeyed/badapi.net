using Nest;
using System;

namespace Sixeyed.BadApi.Indexer.Model
{
    public class ApiResponseDocument
    {
        [String(Index = FieldIndexOption.NotAnalyzed)]
        public string Id { get; set; }

        public DateTime SentTimestamp { get; set; }

        public DateTime ProcessedTimestamp { get; set; }

        public string StatusCode { get; set; }

        [String(Index = FieldIndexOption.NotAnalyzed)]
        public string WebServer { get; set; }

        [String(Index = FieldIndexOption.NotAnalyzed)]
        public string IndexWorker { get; set; }
    }
}
