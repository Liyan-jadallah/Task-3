using MediatR;
using ProductsCleanArchDemo.Application.DTOs;
using ProductsCleanArchDemo.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductsCleanArchDemo.Application.Products.Queries;

public record GetProductsQuery() : IRequest<List<ProductDto>>;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IAppDbContext _context;

    public GetProductsHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AsNoTracking()
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .ToListAsync(cancellationToken);
    }
}