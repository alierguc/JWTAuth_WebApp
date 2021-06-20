using AutoMapper;
using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos;
using Github.JWTApplication.Entities.Dtos.ProductDtos;
using Github.JWTApplication.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
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
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper= mapper;
        }

        [HttpGet("getAllProduct")]
        [Authorize(Roles =RoleInfo.ADMIN+","+RoleInfo.MEMBER)]
        public async Task<IActionResult> GetAll()
        {
            var _products = await _productService.GetAll();
            return Ok(_products);
        }
        [HttpGet("getProductId/{id}")]
        [Authorize(Roles =RoleInfo.ADMIN)]
        public async Task<IActionResult> GetById(int _id)
        {
            var product = await _productService.GetById(_id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost("addProduct")]
        [Authorize(Roles = RoleInfo.ADMIN)]
        [ValidModel]
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
        [HttpPost("updateProduct")]
        [Authorize(Roles = RoleInfo.ADMIN)]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(_mapper.Map<Product>(productUpdateDto));
                return Ok("Ilgili Kayıt Başarıyla Güncellendi.");
            }
            else
            {
                return Forbid();
            }
        }

        [HttpDelete("deleteProduct/{id}")]
        [Authorize(Roles = RoleInfo.ADMIN)]
        [ValidModel]
        public async Task<IActionResult> Delete(int _id)
        {
            await _productService.Remove(new Product() {id = _id });
            return NoContent();
        }

    }
}
