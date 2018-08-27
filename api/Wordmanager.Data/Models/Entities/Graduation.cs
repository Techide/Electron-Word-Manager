using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordmanager.Data.Models.Entities {
  public class Graduation {

    public long Id { get; set; }

    public string Name { get; set; }

    public int Level { get; set; }

    public IEnumerable<Curriculum> Curricula { get; set; }

  }
}
