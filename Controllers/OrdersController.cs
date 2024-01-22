﻿using eShop.Data.Cart;
using eShop.Data.Services;
using eShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel()
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int product_id)
        {
            var item = await _productsService.GetByIdAsync(product_id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
