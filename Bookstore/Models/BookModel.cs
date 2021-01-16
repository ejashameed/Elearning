using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength =5)]
        [Required(ErrorMessage ="Please enter Title of the book")]
        public string Title { get; set; }
        
        [StringLength(50,MinimumLength = 3)]
        [Required]        
        public string Author { get; set; }
        
        [Required]
        public string Description { get; set; }        
        
        public string Category { get; set; }
        
        public string Language { get; set; }
        
        public int TotalPages { get; set; }
    }
}
