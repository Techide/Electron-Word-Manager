using System.Collections.Generic;

namespace Wordmanager.Data.Models.Entities {
  public class Curriculum {
    public long Id { get; set; }

    public long GraduationId { get; set; }
    public Graduation Graduation { get; set; }

    public long FromLanguageId { get; set; }
    public Language FromLanguage { get; set; }

    public long IntoLanguageId { get; set; }
    public Language IntoLanguage { get; set; }

    public ICollection<Translation> Translations { get; set; }
  }
}
