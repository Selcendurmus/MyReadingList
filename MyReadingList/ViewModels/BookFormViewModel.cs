using MyReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.ViewModels
{
    public class BookFormViewModel
    {
        public string Name { get; set; }

        public string Pages { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Reader { get; set; }
        public IEnumerable<Reader>Readers { get; set; }

        public int Level { get; set; }
        public IEnumerable<Level>Levels { get; set; }

        public int Rating { get; set; }
        public IEnumerable<Rating>Ratings { get; set; }

   
        public string Comments { get; set; }
        public object Books { get; internal set; }
    }

}
