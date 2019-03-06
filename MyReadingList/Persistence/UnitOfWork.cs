using MyReadingList.Core;
using MyReadingList.Core.Repositories;
using MyReadingList.Models;
using MyReadingList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; private set; }
        public ILevelRepository Levels { get; private set; }
        public IReaderRepository Readers { get; private set; }
        public IRatingRepository Ratings { get; private set; }

        public UnitOfWork (ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
            Levels = new LevelRepository(context);
            Readers = new ReaderRepository(context);
            Ratings = new RatingRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
