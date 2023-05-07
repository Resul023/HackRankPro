using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Credit.Queries;

public class GetCreditQuery : IRequest<GetCreditDto>
{
    public int Id { get; set; }
}
public class GetCreditDto
{
    public string LoanPurpose { get; set; }
    public string CreditScore { get; set; }
    public float  CreditAmount { get; set; }
    public float  LoanRate { get; set; }
    public int    CreditStatus { get; set; }
    public float  LoanPercentage { get; set; }
    public int?   PaymentHistory { get; set; }
    public int?   CreditHistoryLength { get; set; }
}
public class GetCreditQueryHandler : IRequestHandler<GetCreditQuery, GetCreditDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetCreditQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetCreditDto> Handle(GetCreditQuery request, CancellationToken cancellationToken)
    {
        var value = await _context.Credits.FirstOrDefaultAsync(x=>x.Id == request.Id);
        
        return new GetCreditDto 
        {
            LoanPurpose = value.LoanPurpose ,
            CreditScore = value.CreditScore ,
            CreditAmount = value.CreditAmount ,
            LoanRate = value.LoanRate ,
            PaymentHistory= value.PaymentHistory  ,
            CreditHistoryLength = value.CreditHistoryLength  
        };
    }
}
