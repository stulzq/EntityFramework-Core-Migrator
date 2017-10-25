using EFCoreMigrator.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrator.EntityFrameworkCore
{
	public class BloggingContext: DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BloggingContext;Integrated Security=True");
		}
	}
}