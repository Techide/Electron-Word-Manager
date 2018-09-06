using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Part.Name))]
        public ICollection<Part> Parts { get; set; }
    }
}
