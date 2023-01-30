using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CATEGORY>
    {
        public CategoryValidator() 
        {
            RuleFor(k => k.NAME).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
        }
    }
}