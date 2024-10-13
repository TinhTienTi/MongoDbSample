using System;
using System.Collections.Generic;

namespace MongoDbSample.Dtos
{
    public class OutboxTableDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Dictionary<string, object> Payload { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
