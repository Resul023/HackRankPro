using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Credit.Commands
{
    internal class CreateCreditCommandValidator : AbstractValidator<CreateCreditCommand>
    {
        public CreateCreditCommandValidator()
        {
            RuleFor(x=>x.LoanPurpose)
            .MaximumLength(200)
            .WithMessage("max len must be 200")
            .NotEmpty()
            .WithMessage("LoanPurpose required");
            RuleFor(x=>x.LoanTiming)
            .NotEmpty()
            .WithMessage("LoanTiming required");
            RuleFor(x=>x.CreditAmount)
            .NotEmpty()
            .WithMessage("CreditAmount required");
            RuleFor(x=>x.LoanRate)
            .NotEmpty()
            .WithMessage("LoanRate required");
            RuleFor(x=>x.CreditStatus)
            .NotEmpty()
            .WithMessage("CreditStatus required");
        }
    }
}
