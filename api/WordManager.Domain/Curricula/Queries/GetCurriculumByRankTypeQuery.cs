using DP.CqsLite;

namespace WordManager.Domain.Curricula.Queries
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
