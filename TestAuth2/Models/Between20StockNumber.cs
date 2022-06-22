using System.ComponentModel.DataAnnotations;

namespace VidlyTest.Models
{
    public class Between20StockNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if ( movie.StockNumber == null)
            {
                return new ValidationResult("Stock Number is required !");
            }
            if (movie.StockNumber >= 1 || movie.StockNumber <= 20 )
            {
                return ValidationResult.Success;
            }
            
            return ( movie.StockNumber >= 1 || movie.StockNumber <= 20 || movie.StockNumber == 0 ) 
                ? ValidationResult.Success 
                : new ValidationResult("Stock Number must be between 1 and 20");
        }

    }
}