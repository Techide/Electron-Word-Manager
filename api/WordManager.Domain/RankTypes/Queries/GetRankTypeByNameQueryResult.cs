using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetRankTypeByNameQueryResult
    {

        public GetRankTypeByNameQueryResult(RankTypeDTO result)
        {
            Result = result;
        }

        public RankTypeDTO Result { get; }
    }
}
