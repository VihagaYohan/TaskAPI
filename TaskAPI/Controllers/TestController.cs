using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetTask() 
		{
			var tasks = new String[] { "Task 1", "Task 2", "Task 3" };
			return Ok(tasks);
		}

		[HttpPost]
		public IActionResult NewTask() 
		{
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateTask() 
		{
			return Ok();
		}

		[HttpDelete]
		public IActionResult DeleteTask() 
		{
			return Ok();
		}
	}
}
