using DP.CqsLite;

namespace WordManager.Domain
{
    public class GetCurriculumByRankTypeQuery : IQuery<GetCurriculumByRankTypeQueryResult>
    {
        public GetCurriculumByRankTypeQuery(long rankTypeId)
        {
            RankTypeId = rankTypeId;
        }

        public long RankTypeId { get; private set; }

    }
}
