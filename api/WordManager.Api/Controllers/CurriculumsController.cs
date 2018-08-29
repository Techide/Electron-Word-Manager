using System.Linq;
using DP.CqsLite;
using Microsoft.AspNetCore.Mvc;
using WordManager.Domain.Curricula.Queries;

namespace WordManager.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CurriculumsController : ControllerBase
    {
        private readonly IQueryHandler<GetCurriculumByGraduationAndLanguageQuery, GetCurriculumByGraduationAndLanguageQueryResult> _queryHandler;

        public CurriculumsController(IQueryHandler<GetCurriculumByGraduationAndLanguageQuery, GetCurriculumByGraduationAndLanguageQueryResult> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new System.ArgumentNullException(nameof(queryHandler));
        }

        [HttpPost]
        public ActionResult GetByGraduationAndLanguage(GetCurriculumByGraduationAndLanguageQuery query)
        {
            var result = _queryHandler.Handle(query)?.Curricula.SingleOrDefault();

            return Ok(result);
        }

    }
}
