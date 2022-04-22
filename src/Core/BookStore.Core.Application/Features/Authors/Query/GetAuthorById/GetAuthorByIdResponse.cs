using BookStore.Core.Application.Responses;

namespace BookStore.Core.Application.Features.Authors.Query.GetAuthorById
{
    public class GetAuthorByIdResponse : BaseResponse
    {
        public GetAuthorByIdAuthorDto Author { get; set; }
    }
}
