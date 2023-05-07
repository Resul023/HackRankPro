using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Credit> Credits{ get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
