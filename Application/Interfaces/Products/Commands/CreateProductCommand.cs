using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductsCleanArchDemo.Application.Products.Commands;

public record CreateProductCommand(
    [Required(ErrorMessage = "اسم المنتج مطلوب")]
    [MinLength(2, ErrorMessage = "اسم المنتج يجب أن يكون حرفين على الأقل")]
    string Name,

    [Range(1, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من صفر")]
    decimal Price
) : IRequest<int>;