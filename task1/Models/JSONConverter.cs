using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using task1.Models;

namespace task1
{
    public class JSONConverter
    {

        static public string GetDepositListByMonths(Deposit deposit)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonStr = "";

            DepositCalculator calculator = new DepositCalculator(deposit);

            for (int month = 1; month <= deposit.Months; month++)
            {
                calculator.CurrentMonth = month;
                calculator.AddedSumValue = Math.Round(calculator.DepositCalculate(deposit, month));
                calculator.CurrentSum = deposit.StartSum + calculator.DepositCalculate(deposit, month);
                

                jsonStr += JsonSerializer.Serialize(calculator, options) + "\n";
            }

            

            return jsonStr;

        }


    }
}
