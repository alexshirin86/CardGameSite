using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace CardGameSite.WEB.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите имя товара")]
        [StringLength(50, ErrorMessage = "Имя товара должно состоять от 1 до 50 знаков")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание товара")]
        [StringLength(500, ErrorMessage = "Описание товара должно состоять от 1 до 500 знаков")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Введите цену товара")]
        [Range(0.00, 9999.99, ErrorMessage = "Цена товара должна быть от 0 до 9999.99")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public List<CategoryProduct> CategoriesProduct { get; set; }
    }
}
