using Application.Common.Interfaces;
using WebAPI.Filters;
using Domain.Models.Products;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productRepository.Get(id));
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] InsertProductModel model)
        {
            var created = await _productRepository.Insert(model);

            return Created("created", created);

        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> Put([FromBody] UpdateProductModel model)
        {
            await _productRepository.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.Delete(id);

            return NoContent();
        }
    }
}
