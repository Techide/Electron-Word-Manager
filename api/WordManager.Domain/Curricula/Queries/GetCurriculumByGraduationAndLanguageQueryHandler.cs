using DP.CqsLite;
using System.Linq;
using Wordmanager.Data.Models;
using WordManager.Common.DTO;

namespace WordManager.Domain.Curricula.Queries {
  public class GetCurriculumByGraduationAndLanguageQueryHandler : IQueryHandler<GetCurriculumByGraduationAndLanguageQuery, GetCurriculumByGraduationAndLanguageQueryResult> {
    private readonly WordManagerContext db;

    public GetCurriculumByGraduationAndLanguageQueryHandler(WordManagerContext db) {
      this.db = db ?? throw new System.ArgumentNullException(nameof(db));
    }

    public GetCurriculumByGraduationAndLanguageQueryResult Handle(GetCurriculumByGraduationAndLanguageQuery query) {
      var result = db.Curricula
        .Where(x => x.GraduationId == query.GraduationId)
        .Where(x => x.FromLanguageId == query.FromLanguageId)
        .Where(x => x.IntoLanguageId == query.IntoLanguageId)
        .Select(x => new CurriculumDTO {
          Id = x.Id,
          FromLanguageName = x.FromLanguage.Name,
          IntoLanguageName = x.IntoLanguage.Name
        });
      return new GetCurriculumByGraduationAndLanguageQueryResult(result);
    }
  }
}
