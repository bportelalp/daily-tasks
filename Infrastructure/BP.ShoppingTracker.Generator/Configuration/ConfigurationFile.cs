using BP.ShoppingTracker.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Generator.Configuration
{

    public class ConfigurationFile
    {
        public List<Producttype> ProductTypesTree { get; set; }
        public List<MeasureType> MeasureTypes { get; set; }
    }

    public class Producttype
    {
        public string Name { get; set; }
        public string ProductCategory { get; set; }
        public string Description { get; set; }
        public List<Producttype> ProductTypes { get; set; }
    }
}
