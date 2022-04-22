using BookStore.Core.Application.Responses;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookResponse : BaseResponse
    {
        public AddBookBookDto Book { get; set; }
    }
}
