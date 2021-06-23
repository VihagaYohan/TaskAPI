using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services
{
	public class TodoService
	{
		public List<Todo> AllTodos()
		{
			var todos = new List<Todo>();
			var todo1 = new Todo
			{
				Id = 1,
				Title = "Todo 1",
				Description = "todo description 1",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5)
			};

			var todo2 = new Todo
			{
				Id = 2,
				Title = "Todo 2",
				Description = "Todo description 2",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5)
			};

			var todo3 = new Todo
			{
				Id = 3,
				Title = "Todo 3",
				Description = "Todo description 3",
				Created = DateTime.Now,
				Due = DateTime.Now.AddDays(5)
			};
			todos.Add(todo1);
			todos.Add(todo2);
			todos.Add(todo3);

			return todos;
		}
	}
}
