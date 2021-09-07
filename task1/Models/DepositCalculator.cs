using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
namespace task1.Models
{
    public class DepositCalculator
    {
        public int CurrentMonth { get; set; }
        public double CurrentSum { get; set; }
        public double AddedSumValue { get; set; }

        Deposit deposit;

        public DepositCalculator(Deposit _deposit)
        {
            deposit = _deposit;
        }

        public double DepositCalculate(Deposit deposit, int month)
        {
            return deposit.StartSum * ((month / 12.0) * (0.01 * deposit.Percents));
        }


        
    }
}
