using System;
using System.ComponentModel.DataAnnotations;

namespace MyReadingList.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Level Level { get; set; }

        public string Pages { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public Reader Reader { get; set; }
        
        public string NumberOfReads { get; set; }

        [Required]
        public  Rating Rating { get; set; }

        public string Comments { get; set; }

        public bool IsBookOfTheMonth { get; set; }


    }
}
