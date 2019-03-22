using Microsoft.EntityFrameworkCore;
using MyReadingList.Controllers;
using MyReadingList.Core;
using MyReadingList.Models;
using MyReadingList.ViewModels;
using System;
using System.Linq;
using Xunit;

namespace MyReadingListTest.ControllerTests
{
    public class BooksControllerTests
    {

        [Fact]
        public void Create_WhenCalled_ShouldAddNewBook()
        {
            // Given
            Clock.Freeze();

            var viewModel = new BookFormViewModel
            {
                Id = 1,
                Name = "Selcen's test book",
                Pages = "10",
                Date = Clock.Now().Date.ToString("dd/MM/yyyy"),
                Reader = 1,
                Comments = "-"
            };

            var context = GetDbContext();
            var controller = new BooksController(context);

            // When
            var result = controller.Create(viewModel);


            // Assert
            Assert.Equal(1, context.Books.Count());
            var book = context.Books.First();

            Assert.Equal(1, book.Id);
            Assert.Equal("10", book.Pages);
            Assert.Equal(Clock.Now(), book.DateTime);
            Assert.Equal(1, book.ReaderId);
            Assert.Equal("-", book.Comments);

            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
            
        }

        [Fact]
        public void Details_WhenCalled_ShouldDisplayTheDetailsOfTheBook()
        {
            // Given

            var context = GetDbContext();

            var viewModel = new BookFormViewModel
            {
                Heading = "Details of the Book",
                Id = 2,
                Name = "My Test Book",
                Pages = "15",
                Reader = 1,
                Level = 2,
                Rating = 3,
                Comments = "nice book"

            };

            var controller = new BooksController(context);

            // When
            var result = controller.Create(viewModel);

            // Assert
            Assert.Equal("Details of the Book", viewModel.Heading);
            Assert.Equal(2, viewModel.Id);
            Assert.Equal("My Test Book", viewModel.Name);
            Assert.Equal("15", viewModel.Pages);
            Assert.Equal(1, viewModel.Reader);
            Assert.Equal(2, viewModel.Level);
            Assert.Equal(3, viewModel.Rating);
            Assert.Equal("nice book", viewModel.Comments);
        }


        [Fact]
        public void Update_WhenCalled_ShouldUpdateTheGivenBook()
        {
            // Given
            var context = GetDbContext();

            var bookCreateDate = new DateTime(2007, 1, 26, 19, 7, 1);
            var book = new Book { Id = 1, Name = "Selcen's test book", Pages = "10", DateTime = bookCreateDate, ReaderId = 1, Comments = "-" };

            context.Books.Add(book);
            context.SaveChanges();

            // When
            var controller = new BooksController(context);

            // Then
            var result = controller.Update(new BookFormViewModel
            {
                Id = 1,
                Pages = "25",
                Date = DateTime.Today.AddMonths(1).ToString("d MMM yyyy"),
                Reader = 2,
                Comments = "Nice book",

            });


            // Assert
            context.Entry(book).Reload();
            Assert.Equal(1, context.Books.Count());
            Assert.Equal(1, book.Id);
            Assert.Equal("25", book.Pages);
            Assert.Equal(DateTime.Today.AddMonths(1), book.DateTime);
            Assert.Equal(2, book.ReaderId);
            Assert.Equal("Nice book", book.Comments);


        }


        [Fact]

        public void Delete_WhenCalled_ShouldDeleteTheGivenBook()
        {
            // Given
            var context = GetDbContext();

            context.Add(new Book
            {
                Id = 1,
                Name = "Selcen's test book",
                Pages = "10",
                DateTime = DateTime.Now,
                LevelId = 1,
                ReaderId = 2,
                RatingId = 3,
                Comments = "nice book"
            });



            context.SaveChanges();

            var viewModel = new BookFormViewModel
            {

                Id = 1,
                Name = "Selcen's test book",
                Pages = "10",
                Date = "03/08/2019",
                Level = 1,
                Reader = 2,
                Rating = 3,
                Comments = "nice book"
            };




            // When
            var controller = new BooksController(context);



            // Then
            var result = controller.Delete(viewModel);

            var book = from books in context.Books
                       where books.Id == viewModel.Id
                       select new Book
                       {
                           Id = books.Id,
                           Name = books.Name,
                           Pages = books.Pages,
                           DateTime = books.DateTime,
                           Level = books.Level,
                           Reader = books.Reader,
                           Rating = books.Rating,
                           Comments = books.Comments
                       };


            // Assert
            Assert.Equal(0, context.Books.Count());





        }


        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }

    }
}




