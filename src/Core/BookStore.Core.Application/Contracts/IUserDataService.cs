using System;

namespace BookStore.Core.Application.Contracts
{
    public interface IUserDataService
    {
        public bool IsAuthenticated { get; }
        public Guid UserId { get; }//todo: must set when add identity
        public string CurrentURL { get; }
    }
}
