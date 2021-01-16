using Bookstore.Data;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Category = "",
                TotalPages = bookModel.TotalPages,
                Description = bookModel.Description,
                Language = bookModel.Language,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow                
            };

           await _context.Books.AddAsync(book);
           await _context.SaveChangesAsync();

           return book.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
           var allbooks = await _context.Books.ToListAsync();
           var bookModelList = new List<BookModel>();
           if(allbooks?.Any() == true){
                foreach (var book in allbooks)
                {
                    bookModelList.Add(new BookModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        TotalPages = book.TotalPages,
                        Language = book.Language,
                        Description = book.Description
                    });
                }
            }
           return bookModelList;
        }
        public async Task<BookModel> GetBook(int Id)
        {            
            var book = await _context.Books.Where(x => x.Id == Id).FirstOrDefaultAsync();
            //_context.Books.FromSqlRaw

            var bookModel =  new BookModel()
             {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                TotalPages = book.TotalPages,
                Language = book.Language,
                Description = book.Description
                
            };
            return bookModel;                
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
