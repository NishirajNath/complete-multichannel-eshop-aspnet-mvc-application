﻿using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public string customer_Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public void AddItemToCart(product product) 
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.product.product_id == product.product_id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    product = product,
                    cartItem_Quantitiy = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.cartItem_Quantitiy++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(product product) 
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.product.product_id == product.product_id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.cartItem_Quantitiy > 1) 
                {
                    shoppingCartItem.cartItem_Quantitiy -- ;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }            
            _context.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems() 
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.product).ToList());
        }
        public double GetShoppingCartTotal() 
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => Convert.ToDouble(n.product.product_unitPrice) * n.cartItem_Quantitiy).Sum();
            return total;
        }
    }
}
