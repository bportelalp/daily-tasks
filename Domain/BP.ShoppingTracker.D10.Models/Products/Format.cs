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
        public FormatType FormatType { get; set; }
        public MeasureType MeasureType { get; set; }
        public Format DerivedFormat { get; set; }

        public override string ToString() =>
             ($"{FormatType?.ToString()} de {Value} {MeasureType?.ToString()}") + ((DerivedFormat != null ? $" de {DerivedFormat.ToString()}" : ""));

        public Tuple<Guid, Guid> ComposedId => Tuple.Create(Id, DerivedFormat?.Id?? Guid.Empty);
        public static Guid NoDerivedID => Guid.Empty;
    }
}
