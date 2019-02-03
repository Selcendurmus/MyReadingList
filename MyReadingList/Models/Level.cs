﻿using System.ComponentModel.DataAnnotations;

namespace MyReadingList.Models
{
    public class Level
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
