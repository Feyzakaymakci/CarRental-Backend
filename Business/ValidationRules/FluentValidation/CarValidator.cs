using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c=>c.DailyPrice).GreaterThan(0).WithMessage("Günlük kiralama 0'dan küçük olamaz.");
        

        }
    }
}
