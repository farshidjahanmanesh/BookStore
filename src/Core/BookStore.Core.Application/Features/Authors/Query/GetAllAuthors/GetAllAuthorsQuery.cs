using MediatR;
using System.Text;

namespace BookStore.Core.Application.Features.Authors.Query.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<GetAllAuthorsResponse>
    {
    }
}
