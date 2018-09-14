using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain {
  public class GetCurriculaByRankTypeQueryResult {
    public GetCurriculaByRankTypeQueryResult(IQueryable<CurriculumDTO> curricula) {
      Curricula = curricula;
    }

    public IQueryable<CurriculumDTO> Curricula { get; private set; }

  }
}
