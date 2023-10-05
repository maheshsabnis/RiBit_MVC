using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models.CustomValidators
{
    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(Convert.ToInt32(value) < 0 )
                return false;
            return true;
        }
    }
}