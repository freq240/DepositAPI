using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace task1.Attributes
{
    public class EpsilonRightAttribute : ValidationAttribute
    {

        // Checking accuracy of double/float object, if accuracy < 0.01 - returning false
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int counterDigitsAfterDot = 0;
                string digit = value.ToString();
                
                for(int i = 0; i < digit.Length; i++)
                {
                    if (digit[i].ToString() == "." || digit[i].ToString() == ",")
                    {
                        for(int j = i + 1; i < digit.Length; j++)
                        {
                            counterDigitsAfterDot++;
                        }

                        if (counterDigitsAfterDot >= 0 && counterDigitsAfterDot <= 2)
                        {
                            return true;
                        }        
                    }
                }

                this.ErrorMessage = "Value can not be negative";

            }
            return false;
        }
    }
}
