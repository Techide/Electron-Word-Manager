using Microsoft.AspNetCore.Mvc;
using WordManager.Common.DTO;
using WordManager.Domain.ReadServices;
using WordManager.Domain.WriteServices;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankTypesController : ControllerBase
    {
        private readonly RankTypeReadService _readService;
        private readonly RankTypeWriteService _writeService;

        public RankTypesController(RankTypeReadService readService, RankTypeWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _readService.GetAll();
            return Ok(result);
        }

        [HttpPost(Name = nameof(CreateNewRankType))]
        public ActionResult CreateNewRankType(RankTypeModel rankType)
        {
            //if (rankType == null)
            //{
            //    return BadRequest("rankType");
            //}

            //var validator = new CreateRankTypeValidator();
            //var validation = validator.Validate(rankType);

            //var existing = _getByNameQueryHandler.Handle(new GetRankTypeByNameQuery(rankType.Name));
            //if (existing.Result != null)
            //{
            //    validation.Errors.Add(new ValidationFailure(nameof(rankType.Name), $"En graduering med navnet: {rankType.Name}, findes allerede", new { rankType.Name }));
            //}

            //if (!validation.IsValid)
            //{
            //    return StatusCode(422, validation);
            //}

            //try
            //{
            //    _createNewCommandHandler.Handle(new CreateRankTypeCommand(rankType));
            //    return CreatedAtRoute(RouteData.Values, rankType);
            //}
            //catch (Exception)
            //{
            //    //TODO: Log exception and data;
            //    return StatusCode(500);
            //}
            return Ok();
        }

        [HttpPut(Name = nameof(UpdateRankType))]
        public ActionResult UpdateRankType(RankTypeModel rankType)
        {
            //if (rankType == null)
            //{
            //    return BadRequest("rankType");
            //}

            //var validator = new CreateRankTypeValidator();
            //var validation = validator.Validate(rankType);

            //if (!validation.IsValid)
            //{
            //    return StatusCode(422, validation);
            //}

            //try
            //{
            //    _updateCommandHandler.Handle(new UpdateRankTypeCommand(rankType));
            //    return Ok();
            //}
            //catch (Exception)
            //{
            //    // TODO: Log exception.
            //    return StatusCode(500);
            //}
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteRankType))]
        public ActionResult DeleteRankType(long id)
        {
            //try
            //{
            //    _deleteCommandHandler.Handle(new DeleteRankTypeCommand(id));
            //    return Ok();
            //}
            //catch (Exception)
            //{
            //    // TODO: Log exception.
            //    return StatusCode(500);
            //}
            return Ok();
        }
    }
}
