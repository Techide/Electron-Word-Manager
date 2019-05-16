using Microsoft.AspNetCore.Mvc;
using WordManager.Common.DTO;
using WordManager.Domain.ReadServices;
using WordManager.Domain.WriteServices;

namespace WordManager.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CurriculaController : ControllerBase
    {
        private readonly CurriculumReadService _readService;
        private readonly CurriculumWriteService _writeService;

        public CurriculaController(CurriculumReadService readService, CurriculumWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByRankTypeId(long id)
        {
            var result = _readService.GetByRankType(id);
            return Ok(result);
        }

        [HttpPost(Name = nameof(CreateNewCurriculum))]
        public ActionResult CreateNewCurriculum(CurriculumModel curriculum)
        {
            //if (curriculum == null)
            //{
            //    return Ok();
            //}

            //var validator = new CurriculumValidator();
            //var result = validator.Validate(curriculum);

            //if (_readService.GetByRankAndRankTypeName(curriculum.Rank, curriculum.RankType) != null)
            //{
            //    result.Errors.Add(new ValidationFailure("Dual_Rank_&_RankTypeName", CreateDuplicateRankMessage(curriculum), new { curriculum.Rank, curriculum.RankType }));
            //}

            //if (!result.IsValid)
            //{
            //    return StatusCode(422, result);
            //}

            //try
            //{
            //    _createNewCommandHandler.Handle();
            //    return CreatedAtRoute(RouteData.Values, curriculum);
            //}
            //catch (Exception)
            //{
            //    //TODO: Log exception and data;
            //    return StatusCode(500);
            //}
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCurriculum(CurriculumModel curriculum)
        {

            //if (curriculum == null)
            //{
            //    return Ok();
            //}

            //var validator = new CurriculumValidator();
            //var result = validator.Validate(curriculum);

            //if (_getByRankAndTypeQueryHandler.Handle(new GetCurriculumByRankAndRankTypeQuery(curriculum)).Curriculum == null)
            //{
            //    result.Errors.Add(new ValidationFailure("Invalid_Curriculum_Data", "Forkert data for gradueringen."));
            //}

            //if (!result.IsValid)
            //{
            //    return StatusCode(422, result);
            //}

            //try
            //{
            //    _updateCommandHandler.Handle(new UpdateCurriculumCommand(curriculum));
            //    return Ok(curriculum);
            //}
            //catch (Exception ex)
            //{
            //    //TODO: Log exception and data;
            //    return StatusCode(500);
            //}
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCurriculum(ulong id)
        {
            //try
            //{
            //    _deleteCommandHandler.Handle(new DeleteCurriculumCommand(id));
            //    return Ok(id);
            //}
            //catch (Exception ex)
            //{
            //    //TODO: Log exception;
            //    return StatusCode(500);
            //}
            return Ok();
        }


        private string CreateDuplicateRankMessage(CurriculumModel dto)
        {
            return $"En graduering med niveau {dto.Rank} findes allerede";
        }
    }
}
