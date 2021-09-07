using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1.Extensions
{
    public static class DepositValidationExtensions
    {
        public static void AddFluentDepositValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Deposit>, DepositValidation>();
        }
    }
}
