using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Credit.Queries;
public class GetAllCreditDto
{
    public IEnumerable<GetCreditDto> Credits { get; set; }
}
public class GetAllCreditQuery : IRequest<GetAllCreditDto>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetAllCreditQueryHandler : IRequestHandler<GetAllCreditQuery, GetAllCreditDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllCreditQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<GetAllCreditDto> Handle(GetAllCreditQuery request, CancellationToken cancellationToken)
    {
        return new GetAllCreditDto
        {
            Credits = await _context.Credits
            .AsNoTracking()
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(x => new GetCreditDto
            {
                LoanPurpose = x.LoanPurpose,
                CreditScore = x.CreditScore,
                CreditAmount = x.CreditAmount,
                LoanRate = x.LoanRate,
                PaymentHistory = x.PaymentHistory,
                CreditHistoryLength = x.CreditHistoryLength
            })
            .ToListAsync()
        }; 
    }
}

