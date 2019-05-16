using Microsoft.AspNetCore.Mvc;
using WordManager.Domain.ReadServices;

namespace WordManager.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RankSortOrderController : ControllerBase
    {
        private readonly RankSortOrderReadService _readService;

        public RankSortOrderController(RankSortOrderReadService readService)
        {
            _readService = readService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _readService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(Get))]
        public ActionResult Get(long id)
        {
            var result = _readService.GetById(id);
            return Ok(result);
        }
    }
}
