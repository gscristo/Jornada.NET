using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Entities;
using WebApiRest.Models;
using WebApiRest.Persistence;
using WebApiRest.Persistence.Repositories;

namespace WebApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return Ok(productsViewModel);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);


            if(product == null)
            {
                return StatusCode(404);
            }
            
            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);
            
            return Ok(productDetails);

        }

        [HttpPost]

        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);
            await _repository.AddAsync(product);
            return  CreatedAtAction(nameof(GetById), new {id = product.Id}, model);
        }


        
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Update(model.Description, model.Price);

            await _repository.UpdateAsync(product);

            return NoContent();
        }
    }
}