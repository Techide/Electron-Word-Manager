using DP.CqsLite;
using System;
using System.Linq;
using Wordmanager.Data.Models;
using WordManager.Common.DTO;

namespace WordManager.Domain.Graduations.Queries {
  public class GetAllGraduationsQueryHandler : IQueryHandler<GetAllGraduationsQuery, GetAllGraduationsQueryResult> {
    private readonly WordManagerContext db;

    public GetAllGraduationsQueryHandler(WordManagerContext db) {
      this.db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public GetAllGraduationsQueryResult Handle(GetAllGraduationsQuery query) {
      return new GetAllGraduationsQueryResult(
        db.Graduations.Select(x => new GraduationDTO {
          Id = x.Id,
          Level = x.Level,
          Name = x.Name
        }));
    }

  }
}
