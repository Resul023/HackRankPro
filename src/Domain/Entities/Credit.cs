using Domain.Common;

namespace Domain.Entities;
public class Credit : BaseAuditableEntity
{
    //public string UserId { get; set; }
    public float CreditAmount { get; set; }
    public float LoanRate { get;set; }
    public int LoanPurposeId { get; set; }  
    public LoanPurpose LoanPurpose { get; set; }
    public int CreditId { get; set; }
    public CreditScore CreditScore { get; set; }
}
