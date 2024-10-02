using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Helper;
using Store.Service.Services.ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductEntity = Store.Data.Entities.Product;

namespace Store.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypeDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();
            //var mappedBrands = brands.Select(x => new BrandTypeDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = x.CreatedAt
            //}).ToList();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDto>>(brands);
            return mappedBrands;
        }

        public async Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductAsync(ProductSpecificatiom input)

        {
            var specs = new ProductWithSpecification(input);
            var products = await _unitOfWork.Repository<ProductEntity, int>().GetAllWithSpecificationAsync(specs);
            var countSpecs = new ProductWithCountSpecification(input);
            var count = await _unitOfWork.Repository<ProductEntity, int>().GetCountSpecificationAsync(countSpecs);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);

            return new PaginatedResultDto<ProductDetailsDto>(input.PageSize , input.PageIndex, count, mappedProducts) ;

            //var mappedProducts = products.Select(x => new ProductDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    PictureUrl = x.PictureUrl,
            //    Price = x.Price,
            //    CreatedAt = x.CreatedAt,
            //    BrandName = x.Brand.Name,
            //    TypeName = x.Type.Name
            //}).ToList();

        }
        public async Task<IReadOnlyList<BrandTypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            //var mappedTypes = types.Select(x => new BrandTypeDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = x.CreatedAt
            //}).ToList();
            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDto>>(types);
            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id Is Null");
            var specs = new ProductWithSpecification(productId);
            var product = await _unitOfWork.Repository<ProductEntity, int>().GetWithSpecificationByIdAsync(specs);
            if (product is null)
                throw new Exception("product Is Null");
            //var mappedProduct = new ProductDetailsDto
            //{
            //    Id = productId.Value,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    CreatedAt = product.CreatedAt,
            //    PictureUrl = product.PictureUrl,
            //    BrandName = product.Brand.Name,
            //    TypeName = product.Type.Name
            //};
            var mappedProduct= _mapper.Map<ProductDetailsDto>(product);
            return mappedProduct;
        }
    }
}
