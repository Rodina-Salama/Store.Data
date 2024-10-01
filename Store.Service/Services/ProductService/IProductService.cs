using Store.Service.Services.ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<ProductDetailsDto> GetProductByIdAsync(int? productId);
        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllTypesAsync();

    }
}
