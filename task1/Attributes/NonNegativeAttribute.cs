using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Attributes
{
    public class NonNegativeAttribute : ValidationAttribute
    {

        // Checking validation of digit, true - if it is greater than 0
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                double digit = Convert.ToDouble(value);
                if (digit > 0)
                    return true;
                else
                    this.ErrorMessage = "Value can not be negative";
            }
            return false;
        }
    }
}
