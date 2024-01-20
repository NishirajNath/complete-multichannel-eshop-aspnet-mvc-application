using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Services
{
    public class productsService : IProductsService
    {
        private readonly AppDbContext _context;

        public productsService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public void add(product product)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<product>> GetAll()
        {
            var result =  await _context.Products.ToListAsync();
            return result;
        }

        public async Task<product> GetByIdAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(n => n.product_id == id);
            return result;
        }

        public product update(int id, product newproduct)
        {
            throw new NotImplementedException();
        }
    }
}
