using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class Product : Base.EntityBase
    {
        public Guid ProductTypeFK { get; set; }
        public Guid FormatFK1 { get; set; }
        public Guid FormatFK2 { get; set; }
        public Guid BrandFK { get; set; }
        public int? BarCode { get; set; }

        public ProductType ProductType { get; set; }

        public override string ToString()=> Name + " - " + Id;

    }
}
