using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Wordmanager.Data.Models.Entities;

namespace Wordmanager.Data.Models {
  public class WordManagerContext : DbContext {

    static WordManagerContext() {
      Batteries_V2.Init();
    }

    public WordManagerContext() { }

    public DbSet<Graduation> Graduations { get; set; }
    public DbSet<Curriculum> Curricula { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=WordManagerDataBase.db", options => { options.MigrationsAssembly("WordManager.Api"); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Graduation>().HasIndex(x => x.Level).IsUnique(true);
      base.OnModelCreating(modelBuilder);
    }
  }
}
