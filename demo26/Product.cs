using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo26
{
    public class Product
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int StockQty { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImagePath { get; set; }
    }

}

