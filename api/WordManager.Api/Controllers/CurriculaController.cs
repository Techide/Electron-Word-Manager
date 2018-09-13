using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Common.DTO;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CurriculaController : ControllerBase
    {
        private readonly IQueryHandler<GetCurriculumByRankTypeQuery, GetCurriculumByRankTypeQueryResult> _queryHandler;
        private readonly ICommandHandler<CreateCurriculumCommand> _createNewCommandHandler;

        public CurriculaController(
            IQueryHandler<GetCurriculumByRankTypeQuery, GetCurriculumByRankTypeQueryResult> queryHandler,
            ICommandHandler<CreateCurriculumCommand> createNewCommandHandler
            )
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
            _createNewCommandHandler = createNewCommandHandler ?? throw new System.ArgumentNullException(nameof(createNewCommandHandler));
        }

        [HttpGet("{id}")]
        public ActionResult GetByRankTypeId(ulong id)
        {
            var result = _queryHandler.Handle(new GetCurriculumByRankTypeQuery((long)id));
            return Ok(result.Curricula);
        }

        [HttpPost(Name = nameof(CreateNewCurriculum))]
        public ActionResult CreateNewCurriculum(CurriculumDTO curriculum)
        {
            if (curriculum == null)
            {
                return BadRequest();
            }

            _createNewCommandHandler.Handle(new CreateCurriculumCommand(curriculum));

            return CreatedAtRoute(RouteData.Values, curriculum);
        }
    }
}
