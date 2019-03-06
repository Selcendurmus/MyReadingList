using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Core.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(int bookId);
        IEnumerable<Book> GetBooks(Book book);

        IEnumerable<Book> GetBooks();

        void Add(Book book);
        
        void Remove(Book book );
    }
}





