using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public ViewResult GetBook(int Id)
        {
            var book = _bookRepository.GetBook(Id);
            var books = _bookRepository.GetAllBooks();
            GetBookViewModel _bookViewModel = new GetBookViewModel();
            _bookViewModel.Book = book;
            _bookViewModel.SimilarBooks = books;
            return View(_bookViewModel);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
            
        }
    }
}
