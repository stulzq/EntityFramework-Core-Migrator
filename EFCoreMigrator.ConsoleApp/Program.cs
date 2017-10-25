using System;
using System.Linq;
using EFCoreMigrator.EntityFrameworkCore;
using EFCoreMigrator.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var db = new BloggingContext())
			{
				//检查迁移
				CheckMigrations(db);

				db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
				var count = db.SaveChanges();
				Console.WriteLine("{0} records saved to database", count);

				Console.WriteLine();
				Console.WriteLine("All blogs in database:");
				foreach (var blog in db.Blogs)
				{
					Console.WriteLine(" - {0}", blog.Url);
				}
			}

	        Console.ReadKey();
        }

		/// <summary>
		/// 检查迁移
		/// </summary>
		/// <param name="db"></param>
	    static void CheckMigrations(BloggingContext db)
	    {
		    Console.WriteLine("Check Migrations");

			//判断是否有待迁移
			if (db.Database.GetPendingMigrations().Any())
		    {
				Console.WriteLine("Migrating...");
				//执行迁移
				db.Database.Migrate();
			    Console.WriteLine("Migrated");
			}
		    Console.WriteLine("Check Migrations Coomplete!");
		}
    }
}
