using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.Models
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>

    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Rating> Ratings { get; set; }


      

        public static ApplicationDbContext Create()
         {

            return new ApplicationDbContext();

        }

    }
}



