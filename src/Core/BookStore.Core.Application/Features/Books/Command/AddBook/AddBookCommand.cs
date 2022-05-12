using AutoMapper;
using BookStore.Core.Application.Contracts;

using BookStore.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookCommand : IRequest<AddBookBookDto>, IMapFrom<Book>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Guid AuthorId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddBookCommand, Book>().ReverseMap();
        }
    }
}
