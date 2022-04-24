using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Query.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, GetAllAuthorsResponse>
    {
        private readonly IAsyncAuthorReadRepository _authorRead;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAsyncAuthorReadRepository authorRead, IMapper mapper)
        {
            this._authorRead = authorRead;
            this._mapper = mapper;
        }
        public async Task<GetAllAuthorsResponse> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorRead.GetList();
            var @object = _mapper.Map<List<GetAllAuthorsAuthorDto>>(result);
            return new GetAllAuthorsResponse()
            {
                Authors = @object
            };
        }
    }
}
