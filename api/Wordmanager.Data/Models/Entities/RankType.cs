﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities
{
    public class RankType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long SortOrderId { get; set; }
        public RankSortOrder SortOrder { get; set; }

        [InverseProperty(nameof(Curriculum.RankType))]
        public ICollection<Curriculum> Curricula { get; set; }
    }
}
