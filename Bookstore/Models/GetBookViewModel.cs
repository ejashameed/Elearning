using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class GetBookViewModel
    {
        public BookModel Book { get; set; }
        public List<BookModel> SimilarBooks { get; set; }
    }
}
