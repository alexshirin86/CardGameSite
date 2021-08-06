using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameSite.WEB.Models
{
    public class CategoryProduct
    {
        public int CategoryProductId { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
