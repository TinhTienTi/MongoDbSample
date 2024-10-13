using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbSample.Context.Models;

namespace MongoDbSample.Context.Documents
{
    [BsonCollection("OutboxTable")]
    public class OutboxTable : MongoDocument
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Payload")]
        public BsonDocument Payload { get; set; }
    }
}
