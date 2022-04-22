using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace BookStore.Core.Domain.Entities
{
    public class Basket : Entity<Guid>
    {
        public Guid PurchaserId { get; set; }
        public Purchaser Purchaser { get; set; }
        public ICollection<BasketItem> Items { get; set; }
    }
}
