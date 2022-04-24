using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Core.Domain.Entities
{
    public class Author : Person
    {
        protected Author(string fName, string lName, int age) : base(fName, lName, age)
        {
            _books = new Collection<Book>();
        }
        private Collection<Book> _books;
        public IReadOnlyCollection<Book> Books
        {
            get
            {
                return _books;
            }
        }

        public static Author Create(string fName, string lName, int age)
        {
            if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
                throw new ArgumentNullException("some arguments is null");
            return new Author(fName, lName, age);
        }
        public void AddBook(Book book)
        {
            if (book == null)
                throw new NullReferenceException("book shoudnt be null");
            _books.Add(book);
        }
    }
}
