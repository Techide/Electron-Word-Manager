using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetAllRankTypesQueryResult
    {
        public IQueryable<RankTypeDTO> RankTypes { get; set; }
    }
}
