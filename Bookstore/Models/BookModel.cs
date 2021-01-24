using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Helpers;
using Microsoft.AspNetCore.Http;

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
        [DesiredTextValidator("mvc",ErrorMessage ="Book does not contain the desired text")]
        public string Description { get; set; }        
        
        public string Category { get; set; }
        
        public string Language { get; set; }
        
        public int TotalPages { get; set; }

        [Display(Name ="choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhotos { get; set; }

        public String CoverImageUrl { get; set; }

        [Display(Name = "choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryImages { get; set; }
        public List<GalleryModel> Gallery { get; set; }
    }
}
