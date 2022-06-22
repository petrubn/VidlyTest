using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VidlyTest.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
            var customer = (Customer)validationContext.ObjectInstance;
                 
            if ( customer.MembershipTypeId == MembershipType.Daily || 
                 customer.MembershipTypeId == MembershipType.Weekly )
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("BirthDate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");

            // return base.IsValid(value, validationContext);
        }
        
        
    }
}