using eShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Data.Services;

namespace eShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;            
        }

      

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAll();
            return View(allProducts);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAll();
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n=> n.product_name.Contains(searchString) || n.product_description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            
            return View("Index", allProducts);
        }

        // Get: Products/Details/id
        public async Task<ActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }
    }
}
