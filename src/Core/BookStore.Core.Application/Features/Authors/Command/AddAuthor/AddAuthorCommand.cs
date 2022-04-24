using AutoMapper;
using BookStore.Core.Application.Contracts;
using BookStore.Core.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorCommand : IRequest<AddAuthorResponse>
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
    }
}
