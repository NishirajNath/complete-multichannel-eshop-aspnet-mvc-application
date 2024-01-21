using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Models
{
    public class OrderItem
    {
        [Key]
        public int order_ItemId { get; set; }
        public int order_Itemquantity { get; set; }

        public double order_Itemprice { get; set; }

        public double order_ItemPromoId { get; set; }

        public double order_ItemSubtotal { get; set; }

        public int product_id { get; set; }
        [ForeignKey("product_id")]

        public product product { get; set; }

        public int order_Id { get; set; }
        [ForeignKey("order_Id")]

        public Order Order { get; set; }

    }
}
