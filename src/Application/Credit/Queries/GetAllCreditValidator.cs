using FluentValidation;

namespace Application.Credit.Queries
{
    public class GetAllCreditQueryValidator : AbstractValidator<GetAllCreditQuery>
    {
        public GetAllCreditQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(0).WithMessage("Sayfa numarası 0'dan büyük veya eşit olmalıdır.");

            RuleFor(x => x.Size)
                .InclusiveBetween(1, 100).WithMessage("Boyut, 1 ile 100 arasında bir değer olmalıdır.");
        }
    }
}
