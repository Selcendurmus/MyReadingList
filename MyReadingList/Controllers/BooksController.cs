using Microsoft.AspNetCore.Mvc;
using MyReadingList.Models;
using MyReadingList.ViewModels;
using System.Linq;

namespace MyReadingList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();

        }

        //GET: Books
        public ActionResult Create()
        {
           // var viewModel = new BookFormViewModel
            //{


            //Books = _context.Books.ToList()


            //};

            return View();//viewModel
        }
    }
}


