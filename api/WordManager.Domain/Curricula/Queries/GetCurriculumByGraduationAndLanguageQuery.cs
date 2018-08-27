using DP.CqsLite;

namespace WordManager.Domain.Curricula.Queries {
  public class GetCurriculumByGraduationAndLanguageQuery : IQuery<GetCurriculumByGraduationAndLanguageQueryResult> {

    public long GraduationId { get; set; }

    public long FromLanguageId { get; set; }

    public long IntoLanguageId { get; set; }

  }
}
