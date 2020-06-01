using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkJwt.Business.Interfaces;
using WorksJwt.Entities.Concrete;
using WorksJwt.Entities.DTOs.ProductDtos;
using WorksJwt.WebApi.CustomFilters;

namespace WorksJwt.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
           
                await _productService.InsertAsync(new Product { Name = productAddDto.Name });
                return Created("", productAddDto);
          
           

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return NoContent();
        }

    }
}