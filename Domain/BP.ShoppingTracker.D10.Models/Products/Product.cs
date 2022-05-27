using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class Product : Base.EntityBase
    {
        public Guid Id { get; set; }
        public Guid ProductTypeFK { get; set; }
        public Guid FormatFK { get; set; }
        public Guid BrandFK { get; set; }
        public int? BarCode { get; set; }

        public ProductType ProductType { get; set; }

    }
}
