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
        public bool IsUnitBase { get; set; }
        public int? UnitBaseFK { get; set; }
        public MeasureType UnitBase { get; set; }
        public override string ToString() => Unit;

        public double GetValue(int value)
        {
            if(IsUnitBase) return Convert.ToDouble(value);
            else return value / Convert.ToDouble(ScaleFactorSI);
        }
    }
}
