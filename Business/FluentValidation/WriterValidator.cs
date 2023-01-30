using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class WriterValidator : AbstractValidator<WRITER>
    {
        public WriterValidator() 
        {
            RuleFor(k=>k.NAME).NotEmpty().WithMessage("Ad alanı boş bırakılamaz!");
            RuleFor(k=>k.SURNAME).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz!");
        }
    }
}