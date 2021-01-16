using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return View(books);
        }

        public async Task<ViewResult> GetBook(int Id)
        {
            var book = await _bookRepository.GetBook(Id);
            var books = await _bookRepository.GetAllBooks();
            GetBookViewModel _bookViewModel = new GetBookViewModel();
            _bookViewModel.Book = book;
            _bookViewModel.SimilarBooks = books;
            return View(_bookViewModel);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);            
        }

        public IActionResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            // category list
            ViewBag.CategoryList = new SelectList(GetCategories(),"Id","Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {            
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
                else
                {
                    ModelState.AddModelError("", "Could not save book to the store!");
                }
            }
            ViewBag.CategoryList = new SelectList(GetCategories(), "Id", "Text");
            return View();
        }

        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() {Id = 1, Text = "English"},
                new LanguageModel() {Id = 2, Text = "Spanish"},
                new LanguageModel() {Id = 3, Text = "Arabic" }
            };
        }

        private List<CategoryModel> GetCategories()
        {
            return new List<CategoryModel>()
            {
                new CategoryModel() {Id = 1, Text = "Technology"},
                new CategoryModel() {Id = 2, Text = "Programming"},
                new CategoryModel() {Id = 3, Text = "Drama" }
            };
        }
    }
}
