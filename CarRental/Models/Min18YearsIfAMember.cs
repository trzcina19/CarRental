using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==0)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthdayDate == null)
            {
                return new ValidationResult("Birthday date is required");
            }

            var age = DateTime.Today.Year - customer.BirthdayDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be over 18 years old to go on a membership."); 

            //        return base.IsValid(value, validationContext);
        }
    }
}