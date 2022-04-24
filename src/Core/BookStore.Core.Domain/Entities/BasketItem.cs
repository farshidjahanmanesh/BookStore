using BookStore.Core.Domain.Common;
using System;

namespace BookStore.Core.Domain.Entities
{
    public class BasketItem : Entity<int>
    {
        protected BasketItem(Guid bookId, int count, decimal priceAtTime)
        {
            this.BookId = bookId;
            this.PriceAtTime = priceAtTime;
            this.Count = count;
        }
        public Guid BookId { get; private set; }
        public int Count { get; private set; }
        public decimal PriceAtTime { get; private set; }
        public static BasketItem Create(Guid bookId, int count, decimal priceAtTime)
        {
            Validations(priceAtTime, count, bookId);
            return new BasketItem(bookId, count, priceAtTime);
        }

        private static void Validations(decimal price, int count, Guid bookId)
        {
            var _ = PriceValidation(price) && CountValidation(count);
        }
        private static bool PriceValidation(decimal price) => price > 0 ? true : throw new ArgumentException("مبلغ باید بیشتر از 0 باشد");
        private static bool CountValidation(int count) => count > 0 ? true : throw new ArgumentException("تعداد باید بیشتر از 0 باشد");
    }
}
