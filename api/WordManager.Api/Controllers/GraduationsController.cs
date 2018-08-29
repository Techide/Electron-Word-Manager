using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain.Graduations.Queries;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduationsController : ControllerBase
    {
        private readonly IQueryHandler<GetAllGraduationsQuery, GetAllGraduationsQueryResult> _queryHandler;

        public GraduationsController(IQueryHandler<GetAllGraduationsQuery, GetAllGraduationsQueryResult> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
        }

        // GET api/graduations
        [HttpGet]
        public ActionResult Get()
        {
            var result = _queryHandler.Handle(new GetAllGraduationsQuery())?.Graduations;
            return Ok(result);
        }

        // POST api/graduations
        [HttpPost]
        public void Post()
        {
        }

        // PUT api/graduations/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/graduations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
