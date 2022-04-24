using BookStore.Core.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System;

namespace BookStore.API.REST.Models
{
    public class UserDataService : IUserDataService
    {
        private readonly IHttpContextAccessor _context;

        public UserDataService(IHttpContextAccessor context)
        {
            this._context = context;
        }
        public bool IsAuthenticated { get => throw new NotImplementedException(); }
        public Guid UserId { get => throw new NotImplementedException(); }
        public string CurrentURL { get =>$"{_context.HttpContext.Request.Host}{_context.HttpContext.Request.Path}{_context.HttpContext.Request.QueryString}"; }
    }
}
