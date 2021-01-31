using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name")]        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please enter your email")]  
        [Display(Name ="Email Id")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a valid email Address")]
        public string EmailId { get; set; }
        
        [Required(ErrorMessage ="Please enter a strong password")]
        [Display(Name ="Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        [Required(ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
