using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class Cost
    {
        public Guid Id { get; set; }
        public Guid ProductFK { get; set; }
        public DateTime RegisteredOn { get; set; }
        public double Value { get; set; }
        public bool SalePrice { get; set; }
        public double RateSale { get => SalePrice? _rateSale*100.0 : 0; set { _rateSale = value/100.0; SalePrice = true; } }
        public double RealValue { get => SalePrice ? (Value - (Value / _rateSale)) : Value; }


        private double _rateSale { get; set; }
        
    }
}
