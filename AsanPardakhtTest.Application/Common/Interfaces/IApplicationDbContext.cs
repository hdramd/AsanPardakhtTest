using AsanPardakhtTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsanPardakhtTest.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> People { get; }
        DbSet<Address> Addresses { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
