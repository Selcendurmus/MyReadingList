using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyReadingList.Models;
using MyReadingList.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyReadingList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Book book;

        public int Id { get; private set; }
        public List<Level> Levels { get; private set; }
        public List<Reader> Readers { get; private set; }
        public List<Rating> Ratings { get; private set; }

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
                Heading = "Add a Book",
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookFormViewModel viewModel)
        {
            var book = new Book
            {
                Name = viewModel.Name,
                Pages = viewModel.Pages,
                ReaderId = viewModel.Reader,
                LevelId = viewModel.Level,
                RatingId = viewModel.Rating,
                DateTime = viewModel.GetDateTime(),
                Comments = viewModel.Comments,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        // GET: Books/Details                

        public ActionResult Details(int id)
        {
            var book = _context.Books.Single(b => b.Id == id);

            var viewModel = new BookFormViewModel
            {
                Heading = "Details of the Book",
                Levels = _context.Levels.ToList(),
                Readers = _context.Readers.ToList(),
                Ratings = _context.Ratings.ToList(),
                Date = book.DateTime.ToString("d MMM yyyy"),
                Name = book.Name,
                Pages = book.Pages,
                Reader = book.ReaderId,
                Level = book.LevelId,
                Rating = book.RatingId,
                Comments = book.Comments
            };

            return View("Details", viewModel);

        }


        // GET: Books/Edit
        public ActionResult Edit(int id)
        {
            var book = _context.Books.Single(b => b.Id == id);

            var viewModel = new BookFormViewModel
            {
                Heading = "Edit a Book",
                Id = book.Id,
                Levels = _context.Levels.ToList(),
                Readers = _context.Readers.ToList(),
                Ratings = _context.Ratings.ToList(),
                Date = book.DateTime.ToString("d MMM yyyy"),
                Name = book.Name,
                Pages = book.Pages,
                Reader = book.ReaderId,
                Level = book.LevelId,
                Rating = book.RatingId,
                Comments = book.Comments
            };

            return View("BookForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(BookFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Books = _context.Books.ToList();
                return View("BookForm", viewModel);
            }
            var book = _context.Books.Single(b => b.Id == viewModel.Id);
            {
                book.Name = viewModel.Name;
                book.Pages = viewModel.Pages;
                book.ReaderId = viewModel.Reader;
                book.LevelId = viewModel.Level;
                book.RatingId = viewModel.Rating;
                book.DateTime = viewModel.GetDateTime();
                book.Comments = viewModel.Comments;
            };


            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        //Get: Books/Delete
        public ActionResult Delete(int id)
        {
            var book = _context.Books.Single(b => b.Id == id);

            var viewModel = new BookFormViewModel
            {
                Heading = "Delete the Book",
                Id = book.Id,
                Levels = _context.Levels.ToList(),
                Readers = _context.Readers.ToList(),
                Ratings = _context.Ratings.ToList(),
                Date = book.DateTime.ToString("d MMM yyyy"),
                Name = book.Name,
                Pages = book.Pages,
                Reader = book.ReaderId,
                Level = book.LevelId,
                Rating = book.RatingId,
                Comments = book.Comments
            };

            return View(viewModel);

        }

        // POST: Books/Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BookFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Books = _context.Books.ToList();
                return View("BookForm", viewModel);
            }
            var book = _context.Books.Single(b => b.Id == viewModel.Id);
            {
                book.Name = viewModel.Name;
                book.Pages = viewModel.Pages;
                book.ReaderId = viewModel.Reader;
                book.LevelId = viewModel.Level;
                book.RatingId = viewModel.Rating;
                book.DateTime = viewModel.GetDateTime();
                book.Comments = viewModel.Comments;
            };

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}






