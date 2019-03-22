using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyReadingList.Controllers;
using MyReadingList.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyReadingListTest.ControllerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_OneBookInDatabase_ReturnsOneBookOnView()
        {
            // Given
            var context = GetDbContext();

            var book = new Book { Id = 1, Name = "My First Test by Selcen" };
            context.Books.Add(book);
            context.SaveChanges();

            // When
            var controller = new HomeController(context);

            // Then
            var result = controller.Index();
            var data = GetModel<IEnumerable<Book>>(result);

            
            Assert.Single(data);
            var bookReturned = data.First();
            Assert.Equal(1, bookReturned.Id);
            Assert.Equal("My First Test by Selcen", bookReturned.Name);

        }

        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }

        private T GetModel<T>(IActionResult result)
        {
            var viewResult = (ViewResult)result;

            var data = (T)viewResult.Model;

            return data;
        }
    }
}
