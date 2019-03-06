using MyReadingList.Core.Repositories;
using MyReadingList.Models;
using MyReadingList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly ApplicationDbContext _context;
        public LevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Level> GetLevels()
        {
            return _context.Levels.ToList();

        }
    }

    
 
   
}
