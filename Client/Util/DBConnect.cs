using BeleskeBlazor.Client.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Client.Util
{
    public class DBConnect : DbContext
    {

        public DBConnect(DbContextOptions<DBConnect> options) : base(options)
        {
        }

        public DbSet<Beleska> Beleske { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("seminarskic.database.windows.net");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beleska>().HasKey(b => b.IdBeleska);
        }


    }
}
