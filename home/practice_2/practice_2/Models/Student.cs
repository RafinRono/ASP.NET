using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using practice_2.Extras;

namespace practice_2.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z.-]+$", ErrorMessage="Only characters and . (dot) and - (dash) allowed")]
        public string Name { get; set; }

        [Required, RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage ="ID must be in the format: XX-XXXXX-X Where last X must be [1-3]")]
        public string Id { get; set; }

        [StudentDOBValidation(ErrorMessage = "Age must be atleast 18 years")]
        public DateTime DOB { get; set; }

        [StudentEmailValidation(ErrorMessage = "ID and Email ID do not match")]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string[] Hobbies { get; set; }
    }
}