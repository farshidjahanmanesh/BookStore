using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorAuthorDto>
    {
        private readonly IAsyncWriteRepository<Author> _repo;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAsyncWriteRepository<Author> repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        public async Task<AddAuthorAuthorDto> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorModel = Author.Create(request.FName, request.LName, request.Age);
            var result = await _repo.AddItem(authorModel);
            var author = _mapper.Map<AddAuthorAuthorDto>(result);
            return author;
        }
    }
}
