using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Services.Todos;

namespace TaskAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodosController : ControllerBase
	{
		//private TodoService _todoService;
		private readonly ITodoRepository _todoService;

		public TodosController(ITodoRepository repository)
		{
			//_todoService = new TodoService();
			_todoService = repository;
		}

		[HttpGet("{id?}")]
		public IActionResult GetTotos(int? id) 
		{
			var myTodos = _todoService.AllTodos();
			if (id is null) return Ok(myTodos);

			myTodos = myTodos.Where(t => t.Id == id).ToList();
			return Ok(myTodos);
		}

		[HttpGet("{id}")]
		public IActionResult GetTodo(int id) 
		{
			var todo = _todoService.GetTodo(id);
			if (todo is null) return NotFound();

			return Ok(todo);
		}
	}
}
