using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameSite.WEB.Models
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
