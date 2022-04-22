using BookStore.Core.Domain.Common;
using System;

namespace BookStore.Core.Domain.Entities
{
    public class BasketItem : Entity<int>
    {
        public Guid BookId { get; set; }
        public int Count { get; set; }
        public decimal PriceAtTime { get; set; }
    }
}
