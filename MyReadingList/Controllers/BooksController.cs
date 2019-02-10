using Microsoft.AspNetCore.Mvc;
using MyReadingList.Models;
using MyReadingList.ViewModels;
using System.Linq;

namespace MyReadingList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)

        {
            _context = context;
        }

        //GET: Books

        public ActionResult Create()
        {
            var viewModel = new BookFormViewModel
            {
                Levels = _context.Levels.ToList(),
                Readers = _context.Readers.ToList(),
                Ratings = _context.Ratings.ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(BookFormViewModel viewModel)
        {
            var reader = _context.Readers.Single(r => r.Id == viewModel.Reader);
            var level = _context.Levels.Single(l => l.Id == viewModel.Level);
            var rating = _context.Ratings.Single(r => r.Id == viewModel.Rating);

            var book = new Book
            {
                Name = viewModel.Name,
                Pages = viewModel.Pages,
                Reader = reader,
                Level = level,
                Rating = rating,
                DateTime = viewModel.DateTime,
                Comments = viewModel.Comments,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
