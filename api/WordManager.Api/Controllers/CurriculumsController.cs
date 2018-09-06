using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain.Curricula.Queries;

namespace WordManager.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CurriculumsController : ControllerBase
    {
        private readonly IQueryHandler<GetCurriculumByRankTypeQuery, GetCurriculumByRankTypeQueryResult> _queryHandler;

        public CurriculumsController(IQueryHandler<GetCurriculumByRankTypeQuery, GetCurriculumByRankTypeQueryResult> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
        }

        [HttpPost("{id}")]
        public ActionResult GetByRankTypeId(ulong id)
        {
            var result = _queryHandler.Handle(new GetCurriculumByRankTypeQuery((long)id));
            return Ok(result);
        }

    }
}
