using practice_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace practice_2.Extras
{
    public class StudentEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var student = context.ObjectInstance as Student;

            if (value == null && student.Email == null)
                return new ValidationResult(ErrorMessage = "Null instances");

            var email_id = student.Email.Split('@')[0];

            if (email_id != student.Id)
                return new ValidationResult(ErrorMessage = "ID and Email ID DO NOT match");

            return ValidationResult.Success;
        }
    }
}