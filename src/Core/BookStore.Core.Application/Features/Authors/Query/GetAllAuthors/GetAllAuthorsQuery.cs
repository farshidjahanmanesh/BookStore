
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Features.Authors.Query.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<List<GetAllAuthorsAuthorDto>>
    {
    }
}
