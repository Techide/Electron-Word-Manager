using DP.CqsLite;
using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain.Graduations.Queries {
  public class GetAllGraduationsQuery : IQuery<IQueryable<GraduationDTO>> {
  }
}
