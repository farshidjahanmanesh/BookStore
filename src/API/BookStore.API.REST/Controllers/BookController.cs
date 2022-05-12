using BookStore.API.REST.Models;
using BookStore.Core.Application.Features.Books.Command.AddBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.REST.Controllers
{
    public class BookController : BaseController
    {
        public BookController(ISender sender) : base(sender)
        {

        }

        [HttpPost]
        [ProducesResponseType(typeof(RestResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RestErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
