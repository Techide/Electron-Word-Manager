using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain.RankTypes
{
    public class GetAllRankTypesQueryResult
    {
        public IQueryable<RankTypeDTO> RankTypes { get; set; }
    }
}
