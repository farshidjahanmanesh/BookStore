using BookStore.Core.Application.Responses;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorResponse : BaseResponse
    {
        public AddAuthorAuthorDto Author { get; set; }
    }
}
