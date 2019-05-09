using DP.CqsLite;

namespace WordManager.Domain
{
    public class UpdateCurriculumCommand : ICommand
    {
        public UpdateCurriculumCommand(long id, int rank, string rankType, string color)
        {
            Id = id;
            Rank = rank;
            RankType = rankType;
            Color = color;
        }

        public long Id { get; }
        public int Rank { get; }
        public string RankType { get; }
        public string Color { get; }
    }
}
