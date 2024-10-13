using MongoDbSample.Context.Documents;
using MongoDbSample.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbSample.Interfaces
{
    public interface IOutboxTableService
    {
        Task<OutboxTableDto> DeleteByIdAsync(string id);

        Task<IEnumerable<OutboxTableDto>> GetAsync();

        Task<OutboxTableDto> GetAsync(string id);

        Task<OutboxTableDto> Insert(OutboxTableDto outboxTable);

        Task<OutboxTableDto> UpdateAsync(OutboxTableDto dto);
    }
}
