using eShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class ProductsContoller : Controller
    {
        private readonly AppDbContext _context;

        public ProductsContoller(AppDbContext context)
        {
            _context = context;            
        }
        public IActionResult Index()
        {
            var data = _context.Products.ToList();
            return View();
        }
    }
}
