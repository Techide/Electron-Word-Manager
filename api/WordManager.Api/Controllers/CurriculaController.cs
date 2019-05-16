using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordManager.Api.Validators;
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
            var result = _readService.Get(id);
            return Ok(result);
        }

        [HttpPost(Name = nameof(CreateNewCurriculum))]
        public ActionResult CreateNewCurriculum(CurriculumModel curriculum)
        {
            if (curriculum == null)
            {
                return Ok();
            }

            var validator = new CurriculumValidator();
            var validation = validator.Validate(curriculum);

            if (_readService.Get(curriculum.Rank, curriculum.RankType) != null)
            {
                validation.Errors.Add(new ValidationFailure("Dual_Rank_&_RankTypeName", CreateDuplicateRankMessage(curriculum), new { curriculum.Rank, curriculum.RankType }));
            }

            if (!validation.IsValid)
            {
                return StatusCode(422, validation);
            }

            var result = _writeService.Create(curriculum);

            return CreatedAtAction(nameof(GetByRankTypeId), result);
        }

        [HttpPut]
        public ActionResult UpdateCurriculum(CurriculumModel curriculum)
        {

            if (curriculum == null)
            {
                return Ok();
            }

            var validator = new CurriculumValidator();
            var validation = validator.Validate(curriculum);

            if (_readService.Get(curriculum.Rank, curriculum.RankType) == null)
            {
                validation.Errors.Add(new ValidationFailure("Invalid_Curriculum_Data", "Forkert data for gradueringen."));
            }

            if (!validation.IsValid)
            {
                return BadRequest(validation);
            }

            var result = _writeService.Update(curriculum);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCurriculum(ulong id)
        {
            var result = _writeService.Delete(id);
            return result ? Ok(id) : StatusCode(StatusCodes.Status500InternalServerError, id);
        }

        private string CreateDuplicateRankMessage(CurriculumModel dto)
        {
            return $"En graduering med niveau {dto.Rank} findes allerede";
        }
    }
}
