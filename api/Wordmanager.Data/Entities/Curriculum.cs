using System.Collections.Generic;

namespace Wordmanager.Data.Entities
{
    public class Curriculum : IEntity
    {
        public long Id { get; set; }

        public int Rank { get; set; }

        public long RankTypeId { get; set; }
        public RankType RankType { get; set; }

        public string Color { get; set; }

        public ICollection<Part> Parts { get; set; }

    }
}
