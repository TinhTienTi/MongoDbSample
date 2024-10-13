using MongoDbSample.Context.Documents;
using MongoDbSample.Context.Interfaces;
using MongoDbSample.Dtos;
using MongoDbSample.Interfaces;
using MongoDbSample.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbSample.Services
{
    public class OutboxTableService : IOutboxTableService
    {
        private readonly IMongoRepository<OutboxTable> _repository;

        public OutboxTableService(IMongoRepository<OutboxTable> repository)
        {
            _repository = repository;
        }

        public async Task<OutboxTableDto> DeleteByIdAsync(string id)
        {
            var data = await _repository.DeleteByIdAsync(id);

            return data.ToDto();
        }

        public async Task<OutboxTableDto> GetAsync(string id)
        {
            var data = await _repository.FindByIdAsync(id);

            return data.ToDto();
        }

        public async Task<IEnumerable<OutboxTableDto>> GetAsync()
        {
            var data = await Task.FromResult(_repository.FilterBy(x => true));

            List<OutboxTableDto> result = new List<OutboxTableDto>();

            foreach (var item in data)
            {
                result.Add(item.ToDto());
            }

            return result;
        }

        public async Task<OutboxTableDto> Insert(OutboxTableDto outboxTable)
        {
            var entity = outboxTable.ToEntity();

            var data = await _repository.InsertOneAsync(entity);

            return data.ToDto();
        }

        public async Task<OutboxTableDto> UpdateAsync(OutboxTableDto dto)
        {
            dto.ModifiedAt = DateTimeOffset.UtcNow;

            var data = await _repository.ReplaceOneAsync(dto.ToEntity());

            return data.ToDto();
        }
    }
}
