using BookStore.API.REST.Filters;
using BookStore.Core.Application.Features.Authors.Command.AddAuthor;
using BookStore.Core.Application.Features.Authors.Query.GetAuthorById;
using BookStore.Core.Application.Responses;
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

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetAuthorByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var rsponse = await _sender.Send(new GetAuthorByIdQuery()
            {
                Id = id
            });
            return Ok(rsponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddAuthorResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
