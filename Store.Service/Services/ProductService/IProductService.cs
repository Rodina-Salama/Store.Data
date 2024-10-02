using Store.Repository.Specification.ProductSpecs;
using Store.Service.Helper;
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
        Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductAsync(ProductSpecificatiom specs);
        Task<IReadOnlyList<BrandTypeDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllTypesAsync();

    }
}
