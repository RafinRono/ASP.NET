using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace class2.Models
{
    public class Student
    {
        [Required(ErrorMessage ="You must fill this in, my brother/sister"), StringLength(10)]
        public string Name { get; set; }

        [Range(0,40)]
        public int Id { get; set; }

        [Required, StringLength(15), EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}