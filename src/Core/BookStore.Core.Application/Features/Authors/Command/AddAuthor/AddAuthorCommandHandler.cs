using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorResponse>
    {
        private readonly IAsyncWriteRepository<Author> _repo;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAsyncWriteRepository<Author> repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        public async Task<AddAuthorResponse> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new AddAuthorResponse();
            var author = _mapper.Map<Author>(request);
            var result = await _repo.AddItem(author);
            response.Author = _mapper.Map<AddAuthorAuthorDto>(result);
            return response;
        }
    }
}
