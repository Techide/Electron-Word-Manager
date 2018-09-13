using System;
using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
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

        public RankTypesController(
            IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult> getAllQueryHandler,
            IQueryHandler<GetRankTypeByNameQuery, GetRankTypeByNameQueryResult> getByNameQueryHandler,
            ICommandHandler<CreateRankTypeCommand> createNewCommandHandler
            )
        {
            _getAllQueryHandler = getAllQueryHandler ?? throw new ArgumentNullException(nameof(getAllQueryHandler));
            _getByNameQueryHandler = getByNameQueryHandler ?? throw new ArgumentNullException(nameof(getByNameQueryHandler));
            _createNewCommandHandler = createNewCommandHandler ?? throw new ArgumentNullException(nameof(createNewCommandHandler));
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
                return ValidationProblem(ModelState);
            }

            var existing = _getByNameQueryHandler.Handle(new GetRankTypeByNameQuery(rankType.Name));
            if (existing.Result != null)
            {
                ModelState.AddModelError(nameof(rankType.Name), "Navn findes allerede");
                return ValidationProblem(ModelState);
            }

            _createNewCommandHandler.Handle(new CreateRankTypeCommand(rankType));

            return CreatedAtRoute(nameof(CreateNewRankType), rankType);
        }
    }
}
