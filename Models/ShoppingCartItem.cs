using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int cartItem_Id { get; set; }
        public product product { get; set; }
        public int cartItem_Quantitiy { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
