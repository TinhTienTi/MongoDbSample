using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbSample.Context.Documents;
using MongoDbSample.Dtos;
using MongoDbSample.Interfaces;
using System.Threading.Tasks;

namespace MongoDbSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoDBController : ControllerBase
    {
        private readonly IOutboxTableService _outboxTableService;

        public MongoDBController(IOutboxTableService outboxTableService)
        {
            _outboxTableService = outboxTableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _outboxTableService.GetAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string id)
        {
            try
            {
                var invalidId = new ObjectId(id);
            }
            catch
            {
                return BadRequest();
            }

            var models = await _outboxTableService.GetAsync(id);
            if (models == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(models);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OutboxTableDto outboxTable)
        {
            var data = await _outboxTableService.Insert(outboxTable);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            try
            {
                var invalidId = new ObjectId(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(await _outboxTableService.DeleteByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] OutboxTableDto outboxTable)
        {
            return Ok(await _outboxTableService.UpdateAsync(outboxTable));
        }
    }
}
