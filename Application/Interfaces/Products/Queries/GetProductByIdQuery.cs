using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArchDemo.Application.DTOs;
using ProductsCleanArchDemo.Application.Interfaces;

namespace ProductsCleanArchDemo.Application.Products.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IAppDbContext _context;

    public GetProductByIdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p => p.Id == request.Id)
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .FirstOrDefaultAsync(cancellationToken);
    }
}