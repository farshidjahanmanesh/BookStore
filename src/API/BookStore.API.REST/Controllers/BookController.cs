using BookStore.Core.Application.Features.Books.Command.AddBook;
using BookStore.Core.Application.Responses;
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
        [ProducesResponseType(typeof(AddBookResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
