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
         [Route("api/products/{productId}/productreviews")]
    public class ProductReviewController : ControllerBase
    {  
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductReviewController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id) {
            
            var productReview = await _repository.GetReviewByIdAsync(id);

            if (productReview == null) {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model) {

            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }
    }
}