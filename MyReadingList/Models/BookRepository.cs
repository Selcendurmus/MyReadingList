using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Models
{
    public class BookRepository
    {
        private List<Book> _books = new List<Book>
        {
            new Book{Id=1,Name="The Very Hungry Caterpillar"},
            new Book{Id=2,Name="Goodnight Moon"}
        };

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public Book Create(Book book)
        {
            var nextId = _books.Select(b => b.Id).Max() + 1;
            book.Id = nextId;

            _books.Add(book);

            return book;
        }

        public Book Update(Book book)
        {
            var existing = _books.First(b => b.Id == book.Id);

            existing.Name = book.Name;

            return existing;
        }

        public void Delete(int id)
        {
            var existing = _books.First(b => b.Id == id);

            _books.Remove(existing);
        }
    }
}
