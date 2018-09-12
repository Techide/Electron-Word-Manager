using System;
using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankTypesController : ControllerBase
    {
        private readonly IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult> _queryHandler;

        public RankTypesController(IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _queryHandler.Handle(new GetAllRankTypesQuery());
            return Ok(result.RankTypes);
        }
    }
}
