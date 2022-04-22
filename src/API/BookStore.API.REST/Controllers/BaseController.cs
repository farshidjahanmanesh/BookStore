using BookStore.Core.Application.Features.Books.Command.AddBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.API.REST.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected ISender _sender;
        public BaseController(ISender sender)
        {
            this._sender = sender;
        }
    }
}
