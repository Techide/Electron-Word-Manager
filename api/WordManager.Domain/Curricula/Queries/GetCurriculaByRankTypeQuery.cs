using DP.CqsLite;

namespace WordManager.Domain
{
    public class GetCurriculaByRankTypeQuery : IQuery<GetCurriculaByRankTypeQueryResult>
    {
        public GetCurriculaByRankTypeQuery(long rankTypeId)
        {
            RankTypeId = rankTypeId;
        }

        public long RankTypeId { get; private set; }

    }
}
