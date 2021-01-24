using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Helpers
{
    public class DesiredTextValidatorAttribute : ValidationAttribute
    {
        public string Text { get; set; }

        public DesiredTextValidatorAttribute(string text)
        {
            Text = text;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string bookName = value.ToString();
                if (bookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            //return base.IsValid(value, validationContext);
            return new ValidationResult(ErrorMessage ?? "Book name does not contain the desired text");
        }
    }
}
