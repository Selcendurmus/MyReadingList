using MyReadingList.Core.Repositories;
using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.SingleOrDefault(b => b.Id == bookId);

        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();

        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetBooks(Book book)
        {
            throw new NotImplementedException();
        }
    }   
}
