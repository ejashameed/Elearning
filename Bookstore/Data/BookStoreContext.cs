using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookStoreContext: DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {
            
        }
        public DbSet<Books> Books { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
        //{
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
