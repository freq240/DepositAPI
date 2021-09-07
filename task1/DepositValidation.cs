using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;

namespace task1
{   
    public class DepositValidation : AbstractValidator<Deposit>
    {
        public DepositValidation()
        {
            RuleFor(deposit => deposit.StartSum).NotNull().When(deposit => deposit.StartSum >= 0).WithMessage("Please ensure you have entered data correctly!");
            RuleFor(deposit => deposit.Months).NotNull().When(deposit => deposit.Months > 0).WithMessage("Please ensure you have entered data correctly!");
            RuleFor(deposit => deposit.Percents).NotNull().InclusiveBetween(1, 100).WithMessage("Please ensure you have entered data correctly!");
        }

        // Realisation of checking accuracy of double/float digit to put it in FluentValidation
        private bool BeAValidStartSumEps(double startSum)
        {

            int counterDigitsAfterDot = 0;
            string digit = startSum.ToString();

            for (int i = 0; i < digit.Length; i++)
            {
                if (digit[i].ToString() == "." || digit[i].ToString() == ",")
                {
                    for (int j = i + 1; i < digit.Length; j++)
                    {
                        counterDigitsAfterDot++;
                    }

                    if (counterDigitsAfterDot >= 0 && counterDigitsAfterDot <= 2)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

    }
}
