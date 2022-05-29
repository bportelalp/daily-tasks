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
        public Guid? ParentFK { get; set; }
        public int Value { get; set; }
        public bool? Active { get; set; }
        public FormatType FormatType { get; set; }
        public MeasureType MeasureType { get; set; }
        public Format MainFormat { get; set; }
        public IEnumerable<Format> SubFormats { get; set; }

        public override string ToString() =>
            ((MainFormat!=null? $"{MainFormat.ToString()} de " : "") + $"{FormatType?.ToString()} de {Value} {MeasureType?.ToString()}");
            
    }
}
