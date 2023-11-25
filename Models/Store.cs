using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
    public class Store
    {
        [Key]
        public int store_Id { get; set; }
        public string store_Name { get; set; }
        public string store_PinCode { get; set; }
        public string store_isOpen { get; set;}

        // defining relationship
        public List<product> products { get; set;}

    }



}
