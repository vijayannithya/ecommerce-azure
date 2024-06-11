using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AzureOnlineShop.Models
{
    public class ProductViewModel
    {   
       
        public int product_id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string? product_name { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public int category_id { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public decimal price { get; set; }

        [Required]
        [DisplayName("Product Quantity")]
        public int? qty { get; set; }
    }
}
