﻿using Bookstore.Data;
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
            var newBook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Category = "",
                TotalPages = bookModel.TotalPages,
                Description = bookModel.Description,
                CoverImageUrl = bookModel.CoverImageUrl,
                Language = bookModel.Language,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow                                                                
            };

            // add gallery images
            newBook.BookGallery = new List<BookGallery>();
            foreach (var image in bookModel.Gallery)
            {
                newBook.BookGallery.Add(new BookGallery()
                {
                    ImageUrl = image.ImageUrl,
                    Name = image.Name
                });
            }            
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();

           return newBook.Id;
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
                        Description = book.Description,
                        CoverImageUrl = book.CoverImageUrl
                        
                    });
                }
            }
           return bookModelList;
        }
        public async Task<BookModel> GetBook(int Id)
        {            
            var book = await _context.Books.Where(x => x.Id == Id).FirstOrDefaultAsync();
            //_context.Books.FromSqlRaw

            if(book !=null) 
            {

            }
            var bookModel =  new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                TotalPages = book.TotalPages,
                Language = book.Language,
                Description = book.Description,
                //Gallery = book.BookGallery.Select(g => new GalleryModel()
                //{
                //    Id = g.Id,
                //    Name = g.Name,
                //    ImageUrl = g.ImageUrl
                //}
                //).ToList()
                
            };
            bookModel.Gallery = new List<GalleryModel>();
            var bookGallery = _context.BookGallery.Where(x => x.BookId == book.Id).ToList();
            foreach (var image in bookGallery)
            {
                bookModel.Gallery.Add(new GalleryModel()
                {
                    Id = image.Id,
                    Name = image.Name,
                    ImageUrl = image.ImageUrl
                });
            }
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
