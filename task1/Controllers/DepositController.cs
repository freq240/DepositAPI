using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly ILogger<Deposit> _logger;

        public DepositController(ILogger<Deposit> logger)
        {
            this._logger = logger;
        }


        [HttpGet]
        public string Get(double depositValue, int months, double percents)
        {

            if (ModelState.IsValid)
            { // re-render the view when validation failed.
                return JSONConverter.GetDepositListByMonths(new Deposit(depositValue, months, percents));
            }
            else
            {
                return "Invalid data";
            }
            
        }
    }
}
