using DP.CqsLite;

namespace WordManager.Domain
{
    public class CreateCurriculumCommand : ICommand
    {
        public CreateCurriculumCommand(long id, int rank, string rankType, string color)
        {
            Id = id;
            Rank = rank;
            RankType = rankType;
            Color = color;
        }

        public long Id { get; set; }

        public int Rank { get; set; }

        public string RankType { get; set; }

        public string Color { get; set; }

    }
}
