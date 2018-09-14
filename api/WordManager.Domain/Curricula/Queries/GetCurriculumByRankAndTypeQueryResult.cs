using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetCurriculumByRankAndTypeQueryResult
    {
        public GetCurriculumByRankAndTypeQueryResult(CurriculumDTO curriculum)
        {
            Curriculum = curriculum;
        }

        public CurriculumDTO Curriculum { get; }
    }
}
