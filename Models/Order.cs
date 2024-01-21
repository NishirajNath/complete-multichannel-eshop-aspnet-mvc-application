using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
    public class Order
    {
        [Key]
        public int order_Id { get; set; }
        public int order_Type { get; set; }// 1 for delivery, 2 for pick up

        public string customer_Id { get; set; }
        public string customer_Email { get; set;}
        public string customer_DeliveryAddress { get; set;}

        public double order_Amount { get; set;}
        public int order_PromoId { get; set;}

        public List<OrderItem> OrderItems { get; set; }

    }
}
