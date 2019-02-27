using System;
using System.ComponentModel.DataAnnotations;

namespace MyReadingList.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public string Pages { get; set; }


        public Level Level { get; set; }

        [Required]
        public int LevelId { get; set; }


        public Reader Reader { get; set; }

        [Required]
        public int ReaderId { get; set; }

        public Rating Rating { get; set; }

        [Required]
        public int RatingId { get; set; }

        public DateTime DateTime { get; set; }


        public string Comments { get; set; }


        public string NumberOfReads { get; set; }


        public bool IsBookOfTheMonth { get; set; }

    }
}
