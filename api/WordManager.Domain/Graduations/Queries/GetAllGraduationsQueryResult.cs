using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain.Graduations.Queries {
  public class GetAllGraduationsQueryResult {

    public GetAllGraduationsQueryResult(IQueryable<GraduationDTO> graduations) {
      Graduations = graduations;
    }

    public IQueryable<GraduationDTO> Graduations { get; private set; }

  }
}
