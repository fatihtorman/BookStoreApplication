using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Validation
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {

            RuleFor(Publisher => Publisher.Book).SetValidator(new BookValidator());

            RuleFor(Publisher => Publisher.Quantity)
            .GreaterThan(0).WithMessage("Adet girilmemiş");

            RuleFor(Publisher => Publisher.Status)
            .NotEmpty().WithMessage("Sipariş durumu geçersiz");

        }
    }
}
