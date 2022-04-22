using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Read;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Query.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdResponse>
    {
        private readonly IAsyncAuthorReadRepository _repo;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAsyncAuthorReadRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        public async Task<GetAuthorByIdResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var @object = await _repo.GetAuthorWithBooks(request.Id);
            return new GetAuthorByIdResponse()
            {
                Author = _mapper.Map<GetAuthorByIdAuthorDto>(@object)
            };
        }
    }
}
