using Application.Common.Interfaces;
using MediatR;
using System.Diagnostics.Metrics;

namespace Application.Credit.Commands;
public class CreateCreditCommand : IRequest<int>
{
    public string LoanPurpose { get; set; }
    public string CreditScore { get; set; }
    public float CreditAmount { get; set; }
    public float LoanRate { get; set; }
    public int CreditStatus { get; set; }
    public float LoanPercentage { get; set; }
    public int? PaymentHistory { get; set; }
    public int? CreditHistoryLength { get; set; }
}

public class CreateCreditCommandHandler : IRequestHandler<CreateCreditCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateCreditCommandHandler(IApplicationDbContext context) => this._context = context;
    public async Task<int> Handle(CreateCreditCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Credit entity = new Domain.Entities.Credit
        {
            LoanPurpose = request.LoanPurpose,
            CreditScore = request.CreditScore,
            CreditAmount = request.CreditAmount,
            LoanRate = request.LoanRate,
            CreditStatus = request.CreditStatus,
            LoanPercentage = request.LoanPercentage,
            PaymentHistory = request.PaymentHistory,
            CreditHistoryLength = request.CreditHistoryLength
        };

        await _context.Credits.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}