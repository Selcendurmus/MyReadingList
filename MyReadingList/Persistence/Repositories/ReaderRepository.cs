using MyReadingList.Core.Repositories;
using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDbContext _context;
        public  ReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reader> GetReaders()
        {
            return _context.Readers.ToList();

        }
    }
}
