using BookStore.API.REST.Models;
using BookStore.Core.Application.Features.Authors.Command.AddAuthor;
using BookStore.Core.Application.Features.Authors.Query.GetAllAuthors;
using BookStore.Core.Application.Features.Authors.Query.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStore.API.REST.Controllers
{
    public class AuthorController : BaseController
    {
        public AuthorController(ISender sender) : base(sender)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(RestResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sender.Send(new GetAllAuthorsQuery());

            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RestErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var rsponse = await _sender.Send(new GetAuthorByIdQuery()
            {
                Id = id
            });
            return Ok(rsponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RestResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RestErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
