using MongoDB.Bson;
using MongoDbSample.Context.Documents;
using MongoDbSample.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace MongoDbSample.Mapper
{
    public static class OutboxTableMapper
    {
        public static OutboxTableDto ToDto(this OutboxTable outboxTable)
        {
            if (outboxTable == null)
            {
                return null;
            }

            return new OutboxTableDto
            {
                Id = outboxTable.Id.ToString(), // Assuming MongoDocument has Id of type ObjectId
                Name = outboxTable.Name,
                Email = outboxTable.Email,
                ModifiedAt = outboxTable.ModifiedAt,
                Payload = BsonDocumentToDictionary(outboxTable.Payload)
            };
        }

        public static OutboxTable ToEntity(this OutboxTableDto outboxTableDto)
        {
            if (outboxTableDto == null)
            {
                return null;
            }

            if (outboxTableDto.Id == null)
            {
                return new OutboxTable
                {
                    Name = outboxTableDto.Name,
                    Email = outboxTableDto.Email,
                    ModifiedAt = outboxTableDto.ModifiedAt,
                    Payload = DictionaryToBsonDocument(outboxTableDto.Payload)
                };
            }
            else
            {
                return new OutboxTable
                {
                    Id = new ObjectId(outboxTableDto.Id), // Assuming Id in OutboxTable is an ObjectId
                    Name = outboxTableDto.Name,
                    Email = outboxTableDto.Email,
                    ModifiedAt = outboxTableDto.ModifiedAt,
                    Payload = DictionaryToBsonDocument(outboxTableDto.Payload)
                };
            }
        }

        private static Dictionary<string, object> BsonDocumentToDictionary(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return null;
            }

            return bsonDocument.ToDictionary();
        }

        private static BsonDocument DictionaryToBsonDocument(object dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var jsonDoc = System.Text.Json.JsonSerializer.Serialize(dictionary);

            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonDoc);
        }
    }
}
