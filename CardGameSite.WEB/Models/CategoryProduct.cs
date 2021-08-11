using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CardGameSite.WEB.Models
{
    public class CategoryProduct
    {
        public int CategoryProductId { get; set; }

        [Required(ErrorMessage = "Введите имя товара")]
        [StringLength(20, ErrorMessage = "Имя товара должно состоять от 1 до 20 знаков")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
