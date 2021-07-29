﻿using System;
using System.Collections.Generic;
using System.Text;


namespace CardGameSite.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<CategoryProduct> Categories { get; set; }
    }
}
