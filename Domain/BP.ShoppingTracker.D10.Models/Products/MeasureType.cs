using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class MeasureType : Base.EntityBase
    {
        public new int Id { get; set; }
        public string Unit { get; set; }
        public int ScaleFactorSI { get; set; }
        public override string ToString() => Unit;
    }
}
