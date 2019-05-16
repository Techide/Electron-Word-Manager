using Microsoft.AspNetCore.Mvc;
using WordManager.Domain.ReadServices;
using WordManager.Domain.WriteServices;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly PartReadService _readService;
        private readonly PartWriteService _writeService;

        public PartsController(PartReadService readService, PartWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet("{id}", Name = nameof(GetParts))]
        public ActionResult GetParts(long id)
        {
            var result = _readService.GetManyFromCollectionId(id);
            return Ok(result);
        }

    }
}
