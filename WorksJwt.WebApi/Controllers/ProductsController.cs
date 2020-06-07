using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
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
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            await _productService.InsertAsync(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(product);
            return NoContent();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //loglama

            return Problem("Api Error !");
        }
    }
}