using Microsoft.AspNetCore.Mvc;
using MyReadingList.Core;
using MyReadingList.Models;
using MyReadingList.Persistence;
using MyReadingList.ViewModels;
using System.Linq;

namespace MyReadingList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public BooksController(ApplicationDbContext context)

        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        //GET: Books

        public ActionResult Create()
        {
            var viewModel = new BookFormViewModel
            {
                //Levels = _context.Levels.ToList(),
                Levels = _unitOfWork.Levels.GetLevels(),
                //Readers = _context.Readers.ToList(),
                Readers = _unitOfWork.Readers.GetReaders(),
                //Ratings = _context.Ratings.ToList(),
                ///Ratings = _ratingRepository.GetRatings(),
                Ratings = _unitOfWork.Ratings.GetRatings(),
                Heading = "Add a Book",
            };

            return View("BookForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Create(BookFormViewModel viewModel)
        {
            var book = new Book
            {
                Name = viewModel.Name,
                Pages = viewModel.Pages,
                ReaderId = viewModel.Reader,
                LevelId = viewModel.Level,
                RatingId = viewModel.Rating,
                DateTime = Clock.Now(),// viewModel.GetDateTime(),
                Comments = viewModel.Comments,
            };

            //_context.Books.Add(book);
            _unitOfWork.Books.Add(book);
            //_context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }


        // GET: Books/Details                

        public ViewResult Details(int id)
        {
            //var book = _context.Books.Single(b => b.Id == id);
            var book = _unitOfWork.Books.GetBook(id);

            var viewModel = new BookFormViewModel
            {
                Heading = "Details of the Book",
                //Levels = _context.Levels.ToList(),
                Levels = _unitOfWork.Levels.GetLevels(),
                //Readers = _context.Readers.ToList(),
                Readers = _unitOfWork.Readers.GetReaders(),
                //Ratings = _context.Ratings.ToList(),
                //Ratings = _ratingRepository.GetRatings(),
                Ratings = _unitOfWork.Ratings.GetRatings(),
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
        public ViewResult Edit(int id)
        {
            //var book = _context.Books.Single(b => b.Id == id);
            var book = _unitOfWork.Books.GetBook(id);

            var viewModel = new BookFormViewModel
            {
                Heading = "Edit a Book",
                Id = book.Id,
                //Levels = _context.Levels.ToList(),
                Levels = _unitOfWork.Levels.GetLevels(),
                //Readers = _context.Readers.ToList(),
                Readers = _unitOfWork.Readers.GetReaders(),
                //Ratings = _context.Ratings.ToList(),
                //Ratings = _ratingRepository.GetRatings(),
                Ratings = _unitOfWork.Ratings.GetRatings(),
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
            // var book = _context.Books.Single(b => b.Id == viewModel.Id);
            var book = _unitOfWork.Books.GetBook(viewModel.Id);
            {
                book.Name = viewModel.Name;
                book.Pages = viewModel.Pages;
                book.ReaderId = viewModel.Reader;
                book.LevelId = viewModel.Level;
                book.RatingId = viewModel.Rating;
                book.DateTime = viewModel.GetDateTime();
                book.Comments = viewModel.Comments;
            };


            // _context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }


        //Get: Books/Delete
        public ActionResult Delete(int id)
        {
            //var book = _context.Books.Single(b => b.Id == id);
            var book = _unitOfWork.Books.GetBook(id);


            var viewModel = new BookFormViewModel
            {
                Heading = "Delete the Book",
                Id = book.Id,
                //Levels = _context.Levels.ToList(),
                Levels = _unitOfWork.Levels.GetLevels(),
                //Readers = _context.Readers.ToList(),
                Readers = _unitOfWork.Readers.GetReaders(),
                //Ratings = _context.Ratings.ToList(),
                //Ratings = _ratingRepository.GetRatings(),
                Ratings = _unitOfWork.Ratings.GetRatings(),
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
            //var book = _context.Books.Single(b => b.Id == viewModel.Id);
            var book = _unitOfWork.Books.GetBook(viewModel.Id);
            {
                book.Name = viewModel.Name;
                book.Pages = viewModel.Pages;
                book.ReaderId = viewModel.Reader;
                book.LevelId = viewModel.Level;
                book.RatingId = viewModel.Rating;
                book.DateTime = viewModel.GetDateTime();
                book.Comments = viewModel.Comments;
            };

            //_context.Books.Remove(book);
            _unitOfWork.Books.Remove(book);
            // _context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

    }
}






