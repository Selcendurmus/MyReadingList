using Microsoft.AspNetCore.Mvc;
using MyReadingList.Controllers;
using MyReadingList.ViewModels;
using System;
using Xunit;


namespace MyReadingListTests.Controllers
{
    
    public class BooksControllerTests
    {
        [Fact]
        public void Create_WhenGetMethodIsCalled_ReturnsBookFormViewModel()
        {
            MyReadingList.Models.ApplicationDbContext context = null;
            var controller = new BooksController(context);
            var Result = controller.Create() as ViewResult;
            //Assert.True(BookForm as ViewResult);
            Assert.True("Create", result.BookForm);
        }
    }
}
