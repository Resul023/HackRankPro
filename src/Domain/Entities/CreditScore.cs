using Domain.Common;

namespace Domain.Entities;
public class CreditScore: BaseAuditableEntity
{
    public string Score { get; set; }
}
