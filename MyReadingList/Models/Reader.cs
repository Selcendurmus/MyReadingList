using System.ComponentModel.DataAnnotations;

namespace MyReadingList.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
