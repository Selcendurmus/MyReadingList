using Microsoft.EntityFrameworkCore;

namespace MyReadingList.Models
{
    public interface IReadingListDbContext : IDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Reader> Readers { get; set; }
        DbSet<Rating> Ratings { get; set; }

        DbSet<Level> Levels { get; set; }
    }


    public class ReadingListDbContext : IReadingListDbContext
    {
        public ReadingListDbContext()
        {

        }

        public DbSet<Book> Books { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public DbSet<Reader> Readers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public DbSet<Rating> Ratings { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public DbSet<Level> Levels { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

}
