using eShop.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    public class StoresContoller : Controller
    {
        private readonly AppDbContext _context;

        public StoresContoller(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allStores = await _context.Stores.ToListAsync();
            return View();
        }
    }
}
