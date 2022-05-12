using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Application.Contracts.Persistence.Write;

using BookStore.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookBookDto>
    {
        private readonly IAsyncReadRepository<Author> _authorReadRepo;
        private readonly IAsyncWriteRepository<Author> _authorWriteRepo;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IAsyncReadRepository<Author> authorReadRepo,
            IAsyncWriteRepository<Author> authorWriteRepo, IMapper mapper)
        {
            this._authorReadRepo = authorReadRepo;
            this._authorWriteRepo = authorWriteRepo;
            this._mapper = mapper;
        }
        public async Task<AddBookBookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var @object = Book.Create(request.Title, request.Price, request.Count, request.AuthorId);
            var author = await _authorReadRepo.GetById(request.AuthorId);
            author.AddBook(@object);
            _authorWriteRepo.Update(author);
            return _mapper.Map<AddBookBookDto>(@object);
        }
    }
}
