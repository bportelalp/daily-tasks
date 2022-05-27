using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class Format
    {
        public Guid Id { get; set; }
        public Guid FormatTypeFK { get; set; }
        public int MeasureTypeFK { get; set; }
        public int Value { get; set; }
        public bool? Active { get; set; }
    }
}
