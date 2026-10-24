using Microsoft.EntityFrameworkCore;
using ProductsCleanArchDemo.Application.Interfaces;
using ProductsCleanArchDemo.Domain.Entities;
using ProductsCleanArchDemo.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (!string.IsNullOrEmpty(connectionString))
        options.UseSqlServer(connectionString);
    else
        options.UseInMemoryDatabase("ProductsCleanDb");
});

builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Id = 1, Name = "Laptop", Price = 30000 },
            new Product { Id = 2, Name = "Mechanical Keyboard", Price = 1500 }
        );
        context.SaveChanges();
    }
}

app.MapControllers();

app.Run();