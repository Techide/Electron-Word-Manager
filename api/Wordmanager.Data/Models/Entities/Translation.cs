using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities {
  public class Translation {
    public long Id { get; set; }

    public long CurriculumId { get; set; }
    public Curriculum Curriculum { get; set; }

    public long FromWordId { get; set; }
    public long IntoWordId { get; set; }

    public byte[] Pronounciation { get; set; }

    [ForeignKey(nameof(FromWordId))]
    public Word FromWord { get; set; }

    [ForeignKey(nameof(IntoWordId))]
    public Word IntoWord { get; set; }

  }
}
