using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.BrandName).MinimumLength(2); //b nin brandname ı min 2 karakter olmalı diyoruz burada.
            RuleFor(b=>b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).Must(StartWithA);

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");    //A ile başlıyorsa burası true döner başlamazsa false döner.Bool bir metot
        }
    }
}
