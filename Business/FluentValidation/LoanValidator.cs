using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class LoanValidator : AbstractValidator<MOVEMENT>
    {
        public LoanValidator() 
        {
            RuleFor(k => k.MEMBER).NotEmpty().WithMessage("Kullanıcı kimliği boş bırakılamaz!");
            RuleFor(k => k.EMPLOYEE).NotEmpty().WithMessage("Personel kimliği boş bırakılamaz!");
            RuleFor(k => k.BOOK).NotEmpty().WithMessage("Kitap kimliği boş bırakılamaz!");
        }
    }
}