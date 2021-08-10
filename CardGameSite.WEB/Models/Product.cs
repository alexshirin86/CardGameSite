using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace CardGameSite.WEB.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Введите имя товара")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание товара")]
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(8, 2)")]
        [Required(ErrorMessage = "Введите цену товара")]
        [Range(0.00, double.MaxValue, ErrorMessage = "Цена товара должна быть от 0 и выше.")]
        public decimal Price { get; set; }
        [JsonIgnore]
        public List<CategoryProduct> CategoriesProduct { get; set; }
    }
}
