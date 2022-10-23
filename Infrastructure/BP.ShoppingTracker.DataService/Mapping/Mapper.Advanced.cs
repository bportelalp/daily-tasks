using BP.ShoppingTracker.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.DataService.Mapping
{
    internal partial class Mapper
    {
        public IEnumerable<Models.Products.Format> MapCombinedFormat(IEnumerable<CombinedFormat> combinedFormats) => MapList(combinedFormats, MapCombinedFormat);
        public Models.Products.Format MapCombinedFormat(CombinedFormat combinedFormat)
        {
            if(combinedFormat is null) return null;

            Models.Products.Format format = new Models.Products.Format();
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
