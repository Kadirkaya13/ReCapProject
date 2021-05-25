using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarsValidator:AbstractValidator<Car>
    {
        public CarsValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100000).When(c=>c.BrandId==4);
            //RuleFor(c => c.CarName).Must(StartWithB).WithMessage("İsimler B harfi ile başlamalı");
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
