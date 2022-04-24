using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Domain.Entities
{
    public class Book : Entity<Guid>
    {
        protected Book(string title, decimal price, int count) : base()
        {
            Title = title;
            Price = price;
            Count = count;
        }
        public string Title { get; protected set; }
        public decimal Price { get; protected set; }
        public int Count { get; protected set; }
        public Guid AuthorId { get; protected set; }
        public Author Author { get; protected set; }
        public static Book Create(string title, decimal price, int count, Guid authorId)
        {
            Validations(title, price, count, authorId);
            var b = new Book(title, price, count);
            b.AuthorId = authorId;
            return b;
        }
        private static void Validations(string title, decimal price, int count, Guid authorId)
        {
            var _ = PriceValidation(price) && CountValidation(count) && StringNotEmptyOrNull(title);
        }
        private static bool PriceValidation(decimal price) => price > 0 ? true : throw new ArgumentException("مبلغ باید بیشتر از 0 باشد");
        private static bool CountValidation(int count) => count > 0 ? true : throw new ArgumentException("تعداد باید بیشتر از 0 باشد");
        private static bool StringNotEmptyOrNull(string value) => !string.IsNullOrWhiteSpace(value) ? true : throw new ArgumentException("");
    }
}
