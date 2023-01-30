using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class BookValidator : AbstractValidator<BOOK>
    {
        public BookValidator() 
        {
            RuleFor(k => k.NAME).NotEmpty().WithMessage("Kitap adı boş bırakılamaz!");
            RuleFor(k => k.YEAR).NotEmpty().WithMessage("Basım yılı girilmelidir!");
            RuleFor(k => k.PAGE).NotEmpty().WithMessage("Kitap sayfa bilgisi eksik!");
            RuleFor(k => k.PUBLISH).NotEmpty().WithMessage("Yayınevi bilgisi eksik!");
        }
    }
}