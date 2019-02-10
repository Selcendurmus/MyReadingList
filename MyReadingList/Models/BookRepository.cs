using System.Collections.Generic;
using System.Linq;

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

        public List<Level> GetLevels()
        {
            return new List<Level>
            {
                new Level{Id=1,Name="Easy"},
                new Level{Id=2,Name="Medium"},
                new Level{Id=3,Name="Difficult"},
            };
        }

        public List<Reader> GetReaders()
        {
            return new List<Reader>
            {
                new Reader{Id=1,Name="Self"},
                new Reader{Id=2,Name="Parent"},
                new Reader{Id=3,Name="Teacher"},
            };
        }

        public List<Rating> GetRatings()
        {
            return new List<Rating
                >
            {
                new Rating{Id=1,Name="Excellent"},
                new Rating{Id=2,Name="Very Good"},
                new Rating{Id=3,Name="Good"},
                new Rating{Id=4,Name="Fair"},
                new Rating{Id=5,Name="Poor"},
            };
        }
    }
}
