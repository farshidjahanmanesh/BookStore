﻿
using MediatR;
using System;
using System.Text;

namespace BookStore.Core.Application.Features.Authors.Query.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdAuthorDto>
    {
        public Guid Id { get; set; }
    }
}
