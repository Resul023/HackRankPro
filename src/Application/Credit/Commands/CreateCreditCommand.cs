using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Application.Credit.Commands;
public class CreateCreditCommand : IRequest<int>
{
    public string LoanPurpose { get; set; }
    public int LoanTiming { get; set; }
    public float CreditAmount { get; set; }
    public float LoanRate { get; set; }
    public string? CreditScore { get; set; }
    public bool CreditStatus { get; set; }
    public int? PaymentHistory { get; set; }
    public int? CreditHistoryLength { get; set; }
}



public class CreateCreditCommandHandler : IRequestHandler<CreateCreditCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _contextAccessor;

    public CreateCreditCommandHandler(IApplicationDbContext context, IHttpContextAccessor contextAccessor) 
    {
        this._context = context;
        this._contextAccessor = contextAccessor;
    }
    public async Task<int> Handle(CreateCreditCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Credit entity = new Domain.Entities.Credit
        {
            LoanPurpose = request.LoanPurpose,
            CreditScore = request.CreditScore,
            CreditAmount = request.CreditAmount,
            LoanRate = request.LoanRate,
            PaymentHistory = request.PaymentHistory,
            CreditHistoryLength = request.CreditHistoryLength,
            LoanTiming = request.LoanTiming
        };

        var json = JsonSerializer.Serialize(entity);

        var url = "http://91.102.161.166:5000/predict?data=";
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync(url, json);
        var result = await response.Content.ReadAsStringAsync();
        var value = JsonSerializer.Deserialize<Response>(result);
        entity.CreditStatus = value.result == 0 ? false : true;

        await _context.Credits.AddAsync(entity);

        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
public class Response
{
    public int result { get; set; }
}
