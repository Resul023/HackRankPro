using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Credit.Queries
{
    public class GetCreditDtoValidator : AbstractValidator<GetCreditDto>
    {
        public GetCreditDtoValidator()
        {
            RuleFor(x => x.LoanPurpose)
                .NotEmpty().WithMessage("Kredi amacı boş olamaz.")
                .MaximumLength(500).WithMessage("Kredi amacı en fazla 50 karakter olabilir.");

            RuleFor(x => x.LoanTiming)
                .GreaterThanOrEqualTo(0).WithMessage("Kredi vadesi 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.CreditAmount)
                .GreaterThan(0).WithMessage("Kredi tutarı 0'dan büyük olmalıdır.");

            RuleFor(x => x.LoanRate)
                .GreaterThanOrEqualTo(0).WithMessage("Kredi faiz oranı 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.CreditScore)
                .Must(score => string.IsNullOrEmpty(score) || score.Length == 3).WithMessage("Kredi notu, üç haneli bir sayı veya boş olmalıdır.");

            RuleFor(x => x.CreditStatus)
                .NotNull().WithMessage("Kredi durumu boş olamaz.");

            RuleFor(x => x.PaymentHistory)
                .GreaterThanOrEqualTo(0).WithMessage("Ödeme geçmişi 0'dan büyük veya eşit olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Ödeme geçmişi 100'den küçük veya eşit olmalıdır.")
                .When(x => x.PaymentHistory.HasValue);

            RuleFor(x => x.CreditHistoryLength)
                .GreaterThanOrEqualTo(0).WithMessage("Kredi geçmişi uzunluğu 0'dan büyük veya eşit olmalıdır.")
                .LessThanOrEqualTo(50).WithMessage("Kredi geçmişi uzunluğu 50'den küçük veya eşit olmalıdır.")
                .When(x => x.CreditHistoryLength.HasValue);
        }
    }

}
