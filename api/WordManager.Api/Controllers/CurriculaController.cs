using System;
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
        private readonly IQueryHandler<GetCurriculaByRankTypeQuery, GetCurriculaByRankTypeQueryResult> _queryHandler;
        private readonly IQueryHandler<GetCurriculumByRankAndTypeQuery, GetCurriculumByRankAndTypeQueryResult> _getCurriculumQueryHandler;
        private readonly ICommandHandler<CreateCurriculumCommand> _createNewCommandHandler;

        public CurriculaController(
            IQueryHandler<GetCurriculaByRankTypeQuery, GetCurriculaByRankTypeQueryResult> getCurriculaQueryHandler,
            IQueryHandler<GetCurriculumByRankAndTypeQuery, GetCurriculumByRankAndTypeQueryResult> getCurriculumQueryHandler,
            ICommandHandler<CreateCurriculumCommand> createNewCommandHandler
            )
        {
            _queryHandler = getCurriculaQueryHandler ?? throw new System.ArgumentNullException(nameof(getCurriculaQueryHandler));
            _getCurriculumQueryHandler = getCurriculumQueryHandler ?? throw new System.ArgumentNullException(nameof(getCurriculumQueryHandler));
            _createNewCommandHandler = createNewCommandHandler ?? throw new System.ArgumentNullException(nameof(createNewCommandHandler));
        }

        [HttpGet("{id}")]
        public ActionResult GetByRankTypeId(ulong id)
        {
            var result = _queryHandler.Handle(new GetCurriculaByRankTypeQuery((long)id));
            return Ok(result.Curricula);
        }

        [HttpPost(Name = nameof(CreateNewCurriculum))]
        public ActionResult CreateNewCurriculum(CurriculumDTO curriculum)
        {
            if (curriculum == null)
            {
                return Ok();
            }

            var test = _getCurriculumQueryHandler.Handle(new GetCurriculumByRankAndTypeQuery(curriculum));
            if (test.Curriculum != null)
            {
                ModelState.AddModelError("Dual_Rank_&_RankTypeName", "Graduering findes allerede");
                return ValidationProblem();
            }

            try
            {
                _createNewCommandHandler.Handle(new CreateCurriculumCommand(curriculum));
                return CreatedAtRoute(RouteData.Values, curriculum);
            }
            catch (Exception ex)
            {
                //TODO: Log exception;
                return BadRequest("Unknown error");
            }

        }
    }
}
