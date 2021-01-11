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
                new BookModel(){Id = 1, Title = "MVC Book", Author="Ejas Hameed", Description="Complete MVC step by step",Category="Programming",Language="English",TotalPages=122},
                new BookModel(){Id = 2, Title = "REST API Book", Author="Bruce Willis",Description="REST API Practice and Theory",Category="Programming",Language="English",TotalPages=108},
                new BookModel(){Id = 3, Title = "Java", Author="Mark Antony",Description="Java 2 - The basics and Advanced",Category="Programming",Language="English",TotalPages=111},
                new BookModel(){Id = 4, Title = "C#", Author="Bill Gates",Description="C# - The advanced programming",Category="Programming",Language="English",TotalPages=198},
                new BookModel(){Id = 5, Title = "Python", Author="Cobra",Description="Python for Data Science and Web",Category="Programming",Language="English",TotalPages=100},
                new BookModel(){Id = 6, Title = "Azure Cloud", Author="Thunder",Description="Azure Administrators Bible",Category="Cloud",Language="English",TotalPages=112},
                new BookModel(){Id = 7, Title = "AWS", Author="Jeff Bezos",Description="AWS - Migrate on-premise to Cloud",Category="Cloud",Language="English",TotalPages=128},
              };
        }

    }
}
