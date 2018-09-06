using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;

namespace WordManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduationsController : ControllerBase
    {

        public GraduationsController()
        {
        }

        // POST api/graduations
        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }

        // POST api/graduations/5
        [HttpPost("{id}")]
        public ActionResult GetByCurriculumId(long id)
        {
            return Ok();
        }

        // PUT api/graduations/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, string value)
        {
            return Ok();
        }

        // DELETE api/graduations/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
