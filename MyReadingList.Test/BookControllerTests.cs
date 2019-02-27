using MyReadingList.Controllers;
using System;
using Xunit;

namespace MyReadingList.Test
{
    public class BookControllerTests    
    {
        [Fact]
        public void Edit_ExistingBook_ShowsBookDetails()
        {
            // Given
            var context = new Models.ApplicationDbContext();
            var bookController = new BooksController(context);

            // When
            var result = bookController.Edit(1);

            // Assert


        }
    }
}
