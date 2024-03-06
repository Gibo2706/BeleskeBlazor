using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Client.Util
{
	public class DBConnect : DbContext
	{


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("seminarski.database.windows.net");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}


	}
}
