using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            //RuleFor(Address => Address.Id)
            //.GreaterThan(0).WithMessage("Id alanı boş geçilemez");

            RuleFor(Author => Author.AuthorName)
            .NotEmpty().WithMessage("Yazar adı boş geçilemez!");

            RuleFor(Author => Author.Nation)
            .NotEmpty().WithMessage("Uyruk alanı boş geçilemez!");
            
            RuleFor(Author => Author.Country)
            .NotEmpty().WithMessage("Country alanı boş geçilemez!");
        }
    }
}
