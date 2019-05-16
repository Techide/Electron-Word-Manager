namespace WordManager.Common.DTO
{
    public class CurriculumModel : IModel
    {
        public long Id { get; set; }

        public int Rank { get; set; }

        public string RankType { get; set; }

        public string Color { get; set; }

    }
}
