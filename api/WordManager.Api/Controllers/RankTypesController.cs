using System;
using DP.CqsLite;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WordManager.Api.Validators;
using WordManager.Common.DTO;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankTypesController : ControllerBase
    {
        private readonly IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult> _getAllQueryHandler;
        private readonly IQueryHandler<GetRankTypeByNameQuery, GetRankTypeByNameQueryResult> _getByNameQueryHandler;
        private readonly ICommandHandler<CreateRankTypeCommand> _createNewCommandHandler;
        private readonly ICommandHandler<DeleteRankTypeCommand> _deleteCommandHandler;
        private readonly ICommandHandler<UpdateRankTypeCommand> _updateCommandHandler;

        public RankTypesController(
            IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult> getAllQueryHandler,
            IQueryHandler<GetRankTypeByNameQuery, GetRankTypeByNameQueryResult> getByNameQueryHandler,
            ICommandHandler<CreateRankTypeCommand> createNewCommandHandler,
            ICommandHandler<DeleteRankTypeCommand> deleteCommandHandler,
            ICommandHandler<UpdateRankTypeCommand> updateCommandHandler
            )
        {
            _getAllQueryHandler = getAllQueryHandler ?? throw new ArgumentNullException(nameof(getAllQueryHandler));
            _getByNameQueryHandler = getByNameQueryHandler ?? throw new ArgumentNullException(nameof(getByNameQueryHandler));
            _createNewCommandHandler = createNewCommandHandler ?? throw new ArgumentNullException(nameof(createNewCommandHandler));
            _deleteCommandHandler = deleteCommandHandler ?? throw new ArgumentNullException(nameof(deleteCommandHandler));
            _updateCommandHandler = updateCommandHandler ?? throw new ArgumentNullException(nameof(updateCommandHandler));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _getAllQueryHandler.Handle(new GetAllRankTypesQuery());
            return Ok(result.RankTypes);
        }

        [HttpPost(Name = nameof(CreateNewRankType))]
        public ActionResult CreateNewRankType(RankTypeDTO rankType)
        {
            if (rankType == null)
            {
                return BadRequest("rankType");
            }

            var validator = new CreateRankTypeValidator();
            var validation = validator.Validate(rankType);

            var existing = _getByNameQueryHandler.Handle(new GetRankTypeByNameQuery(rankType.Name));
            if (existing.Result != null)
            {
                validation.Errors.Add(new ValidationFailure(nameof(rankType.Name), $"En graduering med navnet: {rankType.Name}, findes allerede", new { rankType.Name }));
            }

            if (!validation.IsValid)
            {
                return StatusCode(422, validation);
            }

            try
            {
                _createNewCommandHandler.Handle(new CreateRankTypeCommand(rankType));
                return CreatedAtRoute(RouteData.Values, rankType);
            }
            catch (Exception)
            {
                //TODO: Log exception and data;
                return StatusCode(500);
            }

        }

        [HttpPut(Name = nameof(UpdateRankType))]
        public ActionResult UpdateRankType(RankTypeDTO rankType)
        {
            if (rankType == null)
            {
                return BadRequest("rankType");
            }

            var validator = new CreateRankTypeValidator();
            var validation = validator.Validate(rankType);

            if (!validation.IsValid)
            {
                return StatusCode(422, validation);
            }

            try
            {
                _updateCommandHandler.Handle(new UpdateRankTypeCommand(rankType));
                return Ok();
            }
            catch (Exception)
            {
                // TODO: Log exception.
                return StatusCode(500);
            }

        }

        [HttpDelete("{id}", Name = nameof(DeleteRankType))]
        public ActionResult DeleteRankType(long id)
        {
            try
            {
                _deleteCommandHandler.Handle(new DeleteRankTypeCommand(id));
                return Ok();
            }
            catch (Exception)
            {
                // TODO: Log exception.
                return StatusCode(500);
            }
        }
    }
}
