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
        private readonly IQueryHandler<GetPartsFromCollectionIdQuery, PartsQueryResult> _queryHandler;
        private readonly ICommandHandler<CreatePartCommand> _createPartCommandHandler;

        public PartsController(IQueryHandler<GetPartsFromCollectionIdQuery, PartsQueryResult> queryHandler, ICommandHandler<CreatePartCommand> createPartCommandHandler)
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
            _createPartCommandHandler = createPartCommandHandler ?? throw new System.ArgumentNullException(nameof(createPartCommandHandler));
        }

        [HttpGet("{id}", Name = nameof(GetParts))]
        public ActionResult GetParts(long id)
        {
            var result = _queryHandler.Handle(new GetPartsFromCollectionIdQuery(id));
            return Ok(result.Data);
        }

        [HttpPost]
        public ActionResult Post(PartModel part)
        {
            if (part == null)
            {
                return Ok();
            }

            _createPartCommandHandler.Handle(new CreatePartCommand(part));
            return CreatedAtRoute(RouteData.Values, new { part.Id });
        }

        [HttpPut]
        public ActionResult Put(PartModel part)
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
