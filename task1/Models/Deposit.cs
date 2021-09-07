using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using task1.Attributes;
namespace task1
{
    public class Deposit : IValidatableObject
    {
        [Required(ErrorMessage = "Start sum is not exist")]
        [NonNegative]
        [EpsilonRight]
        public double StartSum { get; set; }


        [Required(ErrorMessage = "Start sum is not exist")]
        [NonNegative]
        public int Months { get; set; }

        [Required(ErrorMessage = "Start sum is not exist")]
        [NonNegative]
        [Range(1, 100, ErrorMessage = "Wrong scale of percents")]
        public double Percents { get; set; }


        public Deposit(double value, int months, double percents)
        {
            StartSum = value;
            Months = months;
            Percents = percents;
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            // Negative validation of all props
            if (this.StartSum < 0)
            {
                errors.Add(new ValidationResult("Start sum can NOT be negative value"));
            }
            if (this.Months < 0)
            {
                errors.Add(new ValidationResult("Months can NOT be negative value"));
            }
            if (this.Percents < 0)
            {
                errors.Add(new ValidationResult("Percents can NOT be negative value"));
            }

            // Validation of startSum EPS
            int counterDigitsAfterDot = 0;
            string digit = this.StartSum.ToString();

            for (int i = 0; i < digit.Length; i++)
            {
                if (digit[i].ToString() == "." || digit[i].ToString() == ",")
                {
                    for (int j = i + 1; i < digit.Length; j++)
                    {
                        counterDigitsAfterDot++;
                    }

                    if (counterDigitsAfterDot <= 0 && counterDigitsAfterDot >= 2)
                    {
                        errors.Add(new ValidationResult("Start sum accuracy is NOT expected"));
                    }
                }
            }

            // Validation of percent range [1;100] - including
            if (this.Percents < 1 || this.Percents > 100)
                errors.Add(new ValidationResult("Percents must be in [1;100] range"));

            return errors;
        }


    }
}
