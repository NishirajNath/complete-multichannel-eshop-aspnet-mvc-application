using eShop.Models;

namespace eShop.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<product>> GetAll();

        Task <product> GetByIdAsync(int id);

        void add(product product);

        product update(int id,  product newproduct);

        void delete(int id);


    }
}
