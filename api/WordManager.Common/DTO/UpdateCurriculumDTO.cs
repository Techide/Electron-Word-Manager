namespace WordManager.Common.DTO
{
    public class UpdateCurriculumDTO : CurriculumDTO
    {
        public int OriginalRank { get; set; }

        public string OriginalColor { get; set; }
    }
}
