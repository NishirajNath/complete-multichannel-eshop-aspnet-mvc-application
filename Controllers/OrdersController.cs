using eShop.Data.Cart;
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
        
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            System.Diagnostics.Debug.WriteLine($"Received product_id: {id}");
            var item = await _productsService.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
                //System.Diagnostics.Debug.WriteLine("Items are added and AddItem works1");
            }  //else { System.Diagnostics.Debug.WriteLine("AddItemToCart not working since item is null"); }  
            
            return RedirectToAction(nameof(ShoppingCart));
        }


        
        public async Task<RedirectToActionResult> RemoveItemToShoppingCart(int id)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
                //Console.WriteLine("Items are added and AddItem works1");
            }
            //else { Console.WriteLine("items are not added to cart"); }

            return RedirectToAction(nameof(ShoppingCart));
        } 
    }
}
