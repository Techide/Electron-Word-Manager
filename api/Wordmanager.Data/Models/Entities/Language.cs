using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities {
  public class Language {

    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string CountryCode { get; set; }

    [InverseProperty(nameof(Curriculum.FromLanguage))]
    public ICollection<Curriculum> FromGraduation { get; set; }

    [InverseProperty(nameof(Curriculum.IntoLanguage))]
    public ICollection<Curriculum> IntoGraduation { get; set; }

    public IEnumerable<Word> Words { get; set; }

  }
}
