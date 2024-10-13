using MongoDB.Bson;

namespace MongoDbSample.Context.Documents
{
    public abstract class MongoDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;

        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
