using Domain.Common;

namespace Domain.Entities;
public class LoanPurpose : BaseAuditableEntity
{
    public string Purpose { get; set; }
}
