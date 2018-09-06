using System.Collections.Generic;

namespace Wordmanager.Data.Models.Entities
{
    public class Curriculum
    {
        public long Id { get; set; }

        public int Rank { get; set; }

        public long RankTypeId { get; set; }
        public RankType RankType { get; set; }

        public string Color { get; set; }

        public ICollection<Part> Parts { get; set; }

    }
}
