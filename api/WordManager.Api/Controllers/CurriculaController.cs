using System;
using DP.CqsLite;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WordManager.Api.Validators;
using WordManager.Common.DTO;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CurriculaController : ControllerBase
    {
        private readonly IQueryHandler<GetCurriculaByRankTypeQuery, GetCurriculaByRankTypeQueryResult> _getCurriculaQueryHandler;
        private readonly IQueryHandler<GetCurriculumByRankAndTypeQuery, GetCurriculumByRankAndTypeQueryResult> _getByRankAndTypeQueryHandler;
        private readonly ICommandHandler<CreateCurriculumCommand> _createNewCommandHandler;
        private readonly ICommandHandler<UpdateCurriculumCommand> _updateCommandHandler;
        private readonly ICommandHandler<DeleteCurriculumCommand> _deleteCommandHandler;

        public CurriculaController(
            IQueryHandler<GetCurriculaByRankTypeQuery, GetCurriculaByRankTypeQueryResult> getCurriculaQueryHandler,
            IQueryHandler<GetCurriculumByRankAndTypeQuery, GetCurriculumByRankAndTypeQueryResult> getByRankAndTypeQueryHandler,
            ICommandHandler<CreateCurriculumCommand> createNewCommandHandler,
            ICommandHandler<UpdateCurriculumCommand> updateCommandHandler,
            ICommandHandler<DeleteCurriculumCommand> deleteCommandHandler
            )
        {
            _getCurriculaQueryHandler = getCurriculaQueryHandler ?? throw new ArgumentNullException(nameof(getCurriculaQueryHandler));
            _getByRankAndTypeQueryHandler = getByRankAndTypeQueryHandler ?? throw new ArgumentNullException(nameof(getByRankAndTypeQueryHandler));
            _createNewCommandHandler = createNewCommandHandler ?? throw new ArgumentNullException(nameof(createNewCommandHandler));
            _updateCommandHandler = updateCommandHandler ?? throw new ArgumentNullException(nameof(updateCommandHandler));
            _deleteCommandHandler = deleteCommandHandler ?? throw new ArgumentNullException(nameof(deleteCommandHandler));
        }

        [HttpGet("{id}")]
        public ActionResult GetByRankTypeId(ulong id)
        {
            var result = _getCurriculaQueryHandler.Handle(new GetCurriculaByRankTypeQuery((long)id));
            return Ok(result.Curricula);
        }

        [HttpPost(Name = nameof(CreateNewCurriculum))]
        public ActionResult CreateNewCurriculum(CurriculumDTO curriculum)
        {
            if (curriculum == null)
            {
                return Ok();
            }

            var validator = new CreateCurriculumValidator();
            var result = validator.Validate(curriculum);

            if (_getByRankAndTypeQueryHandler.Handle(new GetCurriculumByRankAndTypeQuery(curriculum)).Curriculum != null)
            {
                result.Errors.Add(new ValidationFailure("Dual_Rank_&_RankTypeName", CreateDuplicateRankMessage(curriculum), new { curriculum.Rank, curriculum.RankType }));
            }

            if (!result.IsValid)
            {
                return StatusCode(422, result);
            }

            try
            {
                _createNewCommandHandler.Handle(new CreateCurriculumCommand(curriculum));
                return CreatedAtRoute(RouteData.Values, curriculum);
            }
            catch (Exception ex)
            {
                //TODO: Log exception and data;
                return BadRequest("Unknown error");
            }

        }

        [HttpPut]
        public ActionResult UpdateCurriculum(UpdateCurriculumDTO curriculum)
        {

            if (curriculum == null)
            {
                return Ok();
            }

            var validator = new CreateCurriculumValidator();
            var result = validator.Validate(curriculum);

            if (curriculum.Rank != curriculum.OriginalRank && _getByRankAndTypeQueryHandler.Handle(new GetCurriculumByRankAndTypeQuery(curriculum)).Curriculum != null)
            {
                result.Errors.Add(new ValidationFailure("Dual_Rank_&_RankTypeName", CreateDuplicateRankMessage(curriculum), new { curriculum.Rank, curriculum.RankType }));
            }

            if (!result.IsValid)
            {
                return StatusCode(422, result);
            }

            try
            {
                _updateCommandHandler.Handle(new UpdateCurriculumCommand(curriculum));
                return Ok(curriculum);
            }
            catch (Exception ex)
            {
                //TODO: Log exception and data;
                return BadRequest("Unknown error");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCurriculum(ulong id)
        {
            try
            {
                _deleteCommandHandler.Handle(new DeleteCurriculumCommand(id));
            }
            catch (Exception ex)
            {
                //TODO: Log exception;
                return BadRequest("Unknown error");
            }
            return Ok(id);
        }


        private string CreateDuplicateRankMessage(CurriculumDTO dto)
        {
            return $"En graduering med niveau {dto.Rank} findes allerede";
        }
    }
}
