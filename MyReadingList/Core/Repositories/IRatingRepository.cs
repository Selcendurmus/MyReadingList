using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Core.Repositories
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetRatings();
    }
}
