using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.DataAccess
{
	public class TodoDbContext:DbContext
	{
		public DbSet<Todo> Todos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Server=LAPTOP-M8FO79SF\\SQLEXPRESS;Database=MyTodoDb;User Id=sa;Password=123456";
			optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().HasData(new Todo
			{
				Id = 1,
				Title = "Todo 1",
				Description = "todo description 1",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5),
				Status=TodoStatus.New
			}); 
		}
	}
}
