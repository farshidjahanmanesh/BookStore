using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Core.Domain.Entities
{
    public class Basket : Entity<Guid>
    {
        protected Basket(Guid PurchaserId)
        {

        }
        public Guid PurchaserId { get; protected set; }
        public Purchaser Purchaser { get; protected set; }
        private Collection<BasketItem> _items = new Collection<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items
        {
            get
            {
                return _items;
            }
        }
        public static Basket Create(Guid purchaserId)
        {
            return new Basket(purchaserId);
        }
        public void AddToBasket(BasketItem item)
        {
            if (item == null)
                throw new ArgumentNullException("BasketItem not be null");
            _items.Add(item);
        }
    }
}
