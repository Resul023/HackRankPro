using Domain.Common;

namespace Domain.Entities;
public class Credit : BaseAuditableEntity
{
    //public string UserId { get; set; }
    public string LoanPurpose { get; set; }
    public int LoanTiming { get; set; }
    public float CreditAmount { get; set; }
    public float LoanRate { get; set; }
    public string? CreditScore { get; set; }
    public bool CreditStatus { get; set; } 
    public int? PaymentHistory { get; set; }
    public int? CreditHistoryLength { get; set; }
}
