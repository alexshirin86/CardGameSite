using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CardGameSite.DAL.Entities
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
