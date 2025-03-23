using practice_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace practice_2.Extras
{
    sealed public class StudentDOBValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                if ((DateTime.Now - date).TotalDays < 18 * 365.25)
                {
                    return false;
                }
            }
            return true;
        }
    }
}