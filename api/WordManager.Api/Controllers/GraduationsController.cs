using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WordManager.Common.DTO;
using WordManager.Domain.Graduations.Queries;

namespace WordManager.Api.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class GraduationsController : ControllerBase {
    private readonly IQueryHandler<GetAllGraduationsQuery, IQueryable<GraduationDTO>> queryHandler;

    public GraduationsController(IQueryHandler<GetAllGraduationsQuery, IQueryable<GraduationDTO>> queryHandler) {
      this.queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
    }

    // GET api/graduations
    [HttpGet]
    public ActionResult Get() {
      var result = queryHandler.Handle(new GetAllGraduationsQuery());
      return Ok(result);
    }


    // POST api/graduations
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/graduations/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/graduations/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }

  }
}
