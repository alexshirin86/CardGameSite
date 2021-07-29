using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameSite.DAL.Entities
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
