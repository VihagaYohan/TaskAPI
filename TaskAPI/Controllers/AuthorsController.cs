using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Services.Authors;
using TaskAPI.Services.ViewModels;

namespace TaskAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorRepository _service;

		public AuthorsController(IAuthorRepository service)
		{
			_service = service;
		}
		
		[HttpGet]
		public IActionResult GetAuthors() 
		{
			//var authors = _service.GetAllAuthors();
			//return Ok(authors);
			var authors = _service.GetAllAuthors();
			var authorsDto = new List<AuthorDto>();

			foreach (var author in authors) 
			{
				authorsDto.Add(new AuthorDto
				{
					Id = author.Id,
					FullName = author.FullName,
					Address = $"{author.Address}, {author.Street}, {author.City}"
				});
			}

			return Ok(authorsDto);
		}

		[HttpGet("{id}")]
		public IActionResult GetAuthor(int id) 
		{
			var author = _service.GetAuthor(id);
			if (author is null) return NotFound();
			return Ok(author);
		}
	}
}
