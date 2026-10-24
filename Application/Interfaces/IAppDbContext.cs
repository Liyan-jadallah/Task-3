using Microsoft.EntityFrameworkCore;
using ProductsCleanArchDemo.Domain.Entities;

namespace ProductsCleanArchDemo.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}