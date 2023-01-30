using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<EMPLOYEE>
    {
        public EmployeeValidator() 
        {
            RuleFor(k => k.EMPLOYEE1).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
        }
    }
}