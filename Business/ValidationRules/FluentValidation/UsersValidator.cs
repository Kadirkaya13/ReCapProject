using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersValidator:AbstractValidator<User>
    {
        public UsersValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.FirstName).MinimumLength(2);
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.LastName).MinimumLength(2);
            RuleFor(c => c.Email).NotEmpty();            
            //RuleFor(c => c.Password).NotEmpty();
            //RuleFor(c => c.Password).MinimumLength(6);
            

        }
        
    }
}
