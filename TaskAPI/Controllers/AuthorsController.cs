using AutoMapper;
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
		private readonly IMapper _mapper;
		public AuthorsController(IAuthorRepository service,IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}
		
		[HttpGet]
		public IActionResult GetAuthors() 
		{
			//var authors = _service.GetAllAuthors();
			//return Ok(authors);
			var authors = _service.GetAllAuthors();
			// var authorsDto = new List<AuthorDto>();

			//foreach (var author in authors) 
			//{
			//	authorsDto.Add(new AuthorDto
			//	{
			//		Id = author.Id,
			//		FullName = author.FullName,
			//		Address = $"{author.Address}, {author.Street}, {author.City}"
			//	});
			//}

			var mappedAuthors = _mapper.Map<ICollection<AuthorDto>>(authors);
			return Ok(mappedAuthors);
		}

		[HttpGet("{id}")]
		public IActionResult GetAuthor(int id) 
		{
			var author = _service.GetAuthor(id);
			if (author is null) return NotFound();

			var mappedAuthor = _mapper.Map<AuthorDto>(author);
			return Ok(mappedAuthor);
		}
	}
}
