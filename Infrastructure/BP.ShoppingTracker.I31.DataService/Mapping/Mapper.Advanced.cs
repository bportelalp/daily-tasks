using BP.ShoppingTracker.D10.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService.Mapping
{
    internal partial class Mapper
    {
        public IEnumerable<D10.Models.Products.Format> MapCombinedFormat(IEnumerable<I30.Persistence.Entities.CombinedFormat> combinedFormats) => MapList(combinedFormats, MapCombinedFormat);
        public D10.Models.Products.Format MapCombinedFormat(I30.Persistence.Entities.CombinedFormat combinedFormat)
        {
            if(combinedFormat is null) return null;

            D10.Models.Products.Format format = new D10.Models.Products.Format();
            format = this.Repo2Domain(combinedFormat.MainFormatFKNavigation);
            format.MeasureType = this.Repo2Domain(combinedFormat.MainFormatFKNavigation.MeasureTypeFKNavigation);
            format.FormatType = this.Repo2Domain(combinedFormat.MainFormatFKNavigation.FormatTypeFKNavigation);
            if (combinedFormat.DerivedFormatFK != Guid.Empty)
            {
                var derived = this.Repo2Domain(combinedFormat.DerivedFormatFKNavigation);
                derived.MeasureType = this.Repo2Domain(combinedFormat.DerivedFormatFKNavigation.MeasureTypeFKNavigation);
                derived.FormatType = this.Repo2Domain(combinedFormat.DerivedFormatFKNavigation.FormatTypeFKNavigation);
                format.DerivedFormat = derived;
            }
            return format;
        }
    }
}
