using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Validation
{
    public class IsbnValidator : AbstractValidator<Isbn>
    {
        public IsbnValidator()
        {
            RuleFor(Isbn => Isbn.Id)
            .GreaterThan(0).WithMessage("ISBN id'si boş!");

            RuleFor(Isbn => Isbn.IsbnNo)
            .NotEmpty().WithMessage("ISBN boş gönderilemez!");

            RuleFor(Isbn => Isbn.book)
            .NotEmpty().WithMessage("Kitap ismi boş geçilemez!");
        }
    }
}
