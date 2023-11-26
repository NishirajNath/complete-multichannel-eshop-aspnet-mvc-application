using eShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Models
{
    public class product
    {
        [Key]
        [Display(Name = "UPC")]
        public int product_UPC { get; set; }
        [Display(Name ="Product Image")]
        public string product_imageUrl { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set;}
        [Display(Name = "Product Description")]
        public string product_description { get; set;}
        [Display(Name = "Product Unit Price")]
        public string product_unitPrice { get; set;}
        [Display(Name = "Product Category")]
        public productCategory product_category { get; set;}
        [Display(Name = "Unit of measurement")]
        public string product_unitOfMeasurement { get; set;}
        [Display(Name = "Product Id")]
        public int product_id { get; set;}
        [Display(Name = "Product Brand")]
        public string product_brand { get; set;}
        [Display(Name = "Product available")]
        public string product_inStock { get; set;}
        [Display(Name = "Expired by")]
        public string product_expirationDate { get; set; }
        [Display(Name = "Promo and offers")]
        public string product_promotion { get; set; }
        [Display(Name = "Store")]
        public string product_availableStore { get; set;}

        // defining relationship with store
        public int store_Id { get; set;}
        [ForeignKey("store_Id")]
        public Store store { get; set; }

    }
}
