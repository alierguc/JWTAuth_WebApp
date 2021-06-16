using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.JWTApplication.WebAPI.Controllers
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
            var _products = await _productService.GetAll();
            return Ok(_products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int _id)
        {
            var product = await _productService.GetById(_id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(new Product { name = productAddDto.name });
                return Created("", productAddDto);
            }
            else
            {
                return BadRequest(productAddDto);
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int _id)
        {
            await _productService.Remove(new Product() {id = _id });
            return NoContent();
        }

    }
}
