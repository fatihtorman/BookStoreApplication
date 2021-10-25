using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            //RuleFor(book => book.Id)
            //.GreaterThan(0).WithMessage("Id alanı 0'dan büyük olmalıdır!");

            RuleFor(book => book.BookName)
            .NotEmpty().WithMessage("Kitap ismi boş geçilemez!");

            RuleFor(book => book.Isbn.Id)
            .GreaterThan(0).WithMessage("Geçerli bir isbn değeri giriniz!");

            RuleFor(book => book.Author).SetValidator(new AuthorValidator());
        }

    }
}
