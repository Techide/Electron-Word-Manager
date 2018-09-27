using System.Collections.Generic;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetAllRankSortOrdersQueryResult
    {
        public GetAllRankSortOrdersQueryResult(IEnumerable<RankSortOrderDTO> data)
        {
            Data = data;
        }

        public IEnumerable<RankSortOrderDTO> Data { get; }
    }
}
