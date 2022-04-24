using BookStore.Core.Application.Responses;
using System.Collections.Generic;

namespace BookStore.Core.Application.Features.Authors.Query.GetAllAuthors
{
    public class GetAllAuthorsResponse : BaseResponse
    {
        public ICollection<GetAllAuthorsAuthorDto> Authors { get; set; }
    }
}
