using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiRest.Entities;

namespace WebApiRest.Persistence.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReviewAsync(ProductReview productReview)
        {
            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext
                        .Products
                        .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetDetailsByIdAsync(int id)
        {
            return await _dbContext
                .Products
                .Include(p => p.Reviews)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductReview> GetReviewByIdAsync(int id)
        {
            return await _dbContext.ProductReviews.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}