using MyReadingList.Core.Repositories;
using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rating> GetRatings()
        {
            return _context.Ratings.ToList();

        }
    }
}
