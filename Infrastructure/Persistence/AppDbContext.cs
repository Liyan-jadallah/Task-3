using Microsoft.EntityFrameworkCore;
using ProductsCleanArchDemo.Application.Interfaces;
using ProductsCleanArchDemo.Domain.Entities;

namespace ProductsCleanArchDemo.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}