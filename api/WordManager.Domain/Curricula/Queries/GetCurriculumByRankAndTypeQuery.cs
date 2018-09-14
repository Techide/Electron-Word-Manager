using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetCurriculumByRankAndTypeQuery : IQuery<GetCurriculumByRankAndTypeQueryResult>
    {
        public GetCurriculumByRankAndTypeQuery(CurriculumDTO dTO)
        {
            Rank = dTO.Rank;
            RankType = dTO.RankType;
        }

        public int Rank { get; }

        public string RankType { get; }
    }
}
