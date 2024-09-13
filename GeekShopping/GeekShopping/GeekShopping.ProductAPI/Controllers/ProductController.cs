﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers {

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController :ControllerBase {

        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id) {
            var product = await _productRepository.FindById(id);

            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll() {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO productVO) {
            if (productVO == null) {
                return BadRequest();
            }
            var produto = _productRepository.Create(productVO);
            return Ok(produto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productVO) {
            if(productVO == null) {
                return BadRequest();
            }
            var produto = _productRepository.Update(productVO);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var status = await _productRepository.DeleteById(id);
            
            if (!status)
                return BadRequest();

            return NoContent();
        }
    }
}
