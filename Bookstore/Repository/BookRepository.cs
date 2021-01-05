using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBook(int Id)
        {
            return DataSource().Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
              {
                new BookModel(){Id = 1, Title = "MVC Book", Author="Ejas Hameed"},
                new BookModel(){Id = 2, Title = "REST API Book", Author="Bruce Willis"},
                new BookModel(){Id = 3, Title = "Java", Author="Mark Antony"},
                new BookModel(){Id = 4, Title = "C#", Author="Bill Gates"},
                new BookModel(){Id = 5, Title = "Python", Author="Cobra"},
                new BookModel(){Id = 6, Title = "Azure Cloud", Author="Thunder"},
                new BookModel(){Id = 7, Title = "AWS", Author="Jeff Bezos"},
              };
        }

    }
}
