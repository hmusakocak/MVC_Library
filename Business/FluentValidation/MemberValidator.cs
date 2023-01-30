using FluentValidation;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.FluentValidation
{
    public class MemberValidator : AbstractValidator<MEMBER>
    {
        public MemberValidator() 
        {
            RuleFor(k=>k.NAME).NotEmpty().WithMessage("Ad alanı boş bırakılamaz!");
            RuleFor(k => k.NAME).MinimumLength(3).WithMessage("Ad üç(3) karakterden daha az uzunlukta olamaz!");
            RuleFor(k=>k.SURNAME).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz!");
            RuleFor(k=>k.MAIL).NotEmpty().WithMessage("E-posta alanı boş bırakılamaz!");
            RuleFor(k=>k.USERNAME).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz!");
            RuleFor(k=>k.PASSWORD).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz!");
            RuleFor(k=>k.SCHOOL).NotEmpty().WithMessage("Okul bilgisi boş bırakılamaz!");
            RuleFor(k=>k.PHONE).NotEmpty().WithMessage("Telefon alanı doldurulmalıdır!");
        }
    }
}