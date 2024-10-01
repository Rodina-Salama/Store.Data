﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.ProductService;
using Store.Service.Services.ProductService.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDto>>> GetAllBrands()
            => Ok(await _productService.GetAllBrandsAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDto>>> GetAllTypes()
        => Ok(await _productService.GetAllTypesAsync());
       // public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProduct()
       //=> Ok(await _productService.GetAllProductAsync());
       // public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
       //=> Ok(await _productService.GetProductByIdAsync(id));
    }
}
