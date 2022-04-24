using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Core.Domain.Entities
{
    public class Purchaser : Person
    {
        protected Purchaser(string fName, string lName, int age) : base(fName, lName, age)
        {

        }
        private Collection<Basket> _baskets = new Collection<Basket>();
        public IReadOnlyCollection<Basket> Baskets
        {
            get { return _baskets; }
        }
        public static Purchaser Create(string fName, string lName, int age)
        {
            if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
                throw new ArgumentNullException("some arguments is null");
            return new Purchaser(fName, lName, age);
        }
    }
}
