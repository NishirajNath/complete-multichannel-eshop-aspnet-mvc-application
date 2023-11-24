using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
    public class product
    {
        [Key]
        public string product_imageUrl { get; set; }
        public string product_name { get; set;}
        public string product_description { get; set;}
        public string product_unitPrice { get; set;} 
        public string product_category { get; set;}
        public string product_unitOfMeasurement { get; set;}
        public int product_id { get; set;}
        public string product_brand { get; set;}
        public string product_inStock { get; set;}
        public string product_expirationDate { get; set; }
        public int product_UPC { get; set; }
        public string product_promotion { get; set; }


    }
}
