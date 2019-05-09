using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain;

namespace WordManager.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RankSortOrderController : ControllerBase
    {
        private readonly IQueryHandler<GetAllRankSortOrdersQuery, RankSortOrderQueryResult> _getAllQueryHandler;

        public RankSortOrderController(IQueryHandler<GetAllRankSortOrdersQuery, RankSortOrderQueryResult> getAllQueryHandler)
        {
            _getAllQueryHandler = getAllQueryHandler ?? throw new System.ArgumentNullException(nameof(getAllQueryHandler));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _getAllQueryHandler.Handle(new GetAllRankSortOrdersQuery());
            return Ok(result.Data);
        }
    }
}
