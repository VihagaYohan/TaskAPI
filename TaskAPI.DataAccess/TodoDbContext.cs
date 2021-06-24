using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.DataAccess
{
	public class TodoDbContext : DbContext
	{
		public DbSet<Todo> Todos { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Server=LAPTOP-M8FO79SF\\SQLEXPRESS;Database=MyTodoDb;User Id=sa;Password=123456";
			optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().HasData(new Todo[]
			{
				new Todo
				{
				Id = 1,
				Title = "Todo 1",
				Description = "todo description 1",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5),
				Status=TodoStatus.New,
				AuthorId=1
				},
				 new Todo
			{
				Id = 2,
				Title = "Todo 2",
				Description = "Todo description 2",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5),
				Status = TodoStatus.Inprogress,
				AuthorId=2
			},
				new Todo
			{
				Id = 3,
				Title = "Todo 3",
				Description = "Todo description 3",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5),
				Status = TodoStatus.Completed,
				AuthorId=3
			}
			});

			modelBuilder.Entity<Author>().HasData(new Author[]
			{
				new Author{ Id=1, FullName="Author 1",Address="Address 1",Street="Street 1",City="City 1"},
				new Author{ Id=2, FullName="Author 2",Address="Address 2",Street="Street 2",City="City 2"},
				new Author{ Id =3, FullName="Author 3",Address="Address 3",Street="Street 3",City="City 3"},
				new Author{ Id=4, FullName="Author 4",Address="Address 4",Street="Street 4",City="City 4"}
			});
		}
	}
}
