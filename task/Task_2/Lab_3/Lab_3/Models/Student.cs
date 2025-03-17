using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Lab_3.Models
{
    sealed public class validateDOB : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false; 
            }

            if (DateTime.TryParse(value.ToString(), out DateTime dateValue))
            {
                if ((DateTime.Now - dateValue).TotalDays >= 18 * 365.25)
                {
                    return true; 
                }
                return false;
            }

            return false;
        }
    }

    sealed public class validateIdEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = validationContext.ObjectInstance as Student;
            if (student == null || value == null)
            {
                return new ValidationResult(ErrorMessage = "Id and Email-Id do Not match") { };
            }

            var emailIdPortion = student.Email.Split('@')[0];

            if (student.Id != emailIdPortion)
            {
                return new ValidationResult(ErrorMessage = "Id and Email-Id do Not match") { };
            }
            return ValidationResult.Success; 
        }
    }


    public class Student
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z.-]+$", ErrorMessage = "Name only contains alphabets, . (dot) and - (dash)")]
        public string Name { get; set; }

        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "XX-XXXXX-X format with only digits and last digit must be between 1-3")]
        public string Id { get; set; }
        [validateDOB(ErrorMessage = "Must be atleast 18 years of age")]
        public string DOB { get; set; }
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student.aiub.edu$", ErrorMessage = "Must be in this format: XX-XXXXX-X@student.aiub.edu")]
        [validateIdEmail(ErrorMessage ="test")]
        public string Email { get; set; }
    }
}