using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities {
  public class Word {
    public long Id { get; set; }

    [Required]
    public string Value { get; set; }

    public long LanguageId { get; set; }
    public Language Language { get; set; }

    [InverseProperty(nameof(Translation.FromWord))]
    public Translation FromTranslation { get; set; }

    [InverseProperty(nameof(Translation.IntoWord))]
    public Translation IntoTranslation { get; set; }

  }
}
