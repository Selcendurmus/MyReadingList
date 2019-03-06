using MyReadingList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Core
{
    public interface IUnitOfWork
    {
        IBookRepository Books {get; }
        ILevelRepository Levels { get; }
        IReaderRepository Readers { get; }
        IRatingRepository Ratings { get; }
        void Complete();

    }
}


