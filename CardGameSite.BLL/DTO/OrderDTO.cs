using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameSite.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }
        public DateTime? Date { get; set; }
    }
}
