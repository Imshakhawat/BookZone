using BookZone.Models;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

	}
}
