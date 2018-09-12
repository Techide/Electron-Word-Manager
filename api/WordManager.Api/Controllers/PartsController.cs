using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IQueryHandler<GetPartsFromCollectionIdQuery, GetPartsFromCollectionIdQueryResult> _queryHandler;

        public PartsController(IQueryHandler<GetPartsFromCollectionIdQuery, GetPartsFromCollectionIdQueryResult> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
        }

        // GET: api/Parts/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(long id)
        {
            var result = _queryHandler.Handle(new GetPartsFromCollectionIdQuery(id));
            return Ok(result.Data);
        }

        // POST: api/Parts
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT: api/Parts/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
