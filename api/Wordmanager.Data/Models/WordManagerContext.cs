using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Wordmanager.Data.Models.Entities;

namespace Wordmanager.Data.Models
{
    public class WordManagerContext : DbContext
    {

        static WordManagerContext()
        {
            Batteries_V2.Init();
        }

        public WordManagerContext() { }

        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<RankSortOrder> RankSortOrders { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<RankType> RankTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WordManagerDataBase.db", options => { options.MigrationsAssembly("WordManager.Api"); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curriculum>().HasIndex(x => new { x.Rank, x.RankTypeId }).IsUnique(true);
            modelBuilder.Entity<Part>().HasMany(x => x.SubParts).WithOne(x => x.ParentPart).HasForeignKey(x => x.ParentPartId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
