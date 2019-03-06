using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MyReadingList.Core;
using MyReadingList.Models;
using MyReadingList.Persistence;
using MyReadingList.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyReadingList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public List<Level> Levels { get; private set; }
        public List<Reader> Readers { get; private set; }
        public List<Rating> Ratings { get; private set; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        public IActionResult Index()
        {
            //var myBooks = _context.Books.ToList();
            var myBooks = _unitOfWork.Books.GetBooks();
            
            return View(myBooks);
        }
               
               
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
    }
}
