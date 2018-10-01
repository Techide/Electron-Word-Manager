using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Common.DTO;
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

        [HttpGet("{id}", Name = nameof(GetParts))]
        public ActionResult GetParts(long id)
        {
            var result = _queryHandler.Handle(new GetPartsFromCollectionIdQuery(id));
            return Ok(result.Data);
        }

        [HttpPost]
        public ActionResult Post(PartDTO part)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(PartDTO part)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
