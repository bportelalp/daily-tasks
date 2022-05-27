using BP.ShoppingTracker.D10.Models.Products;
using BP.ShoppingTracker.D20.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService
{
    public partial class DataService : IDataService
    {
        public async Task<IEnumerable<ProductType>> UpdateProductTypes(IEnumerable<ProductType> productType)
        {
            var entity = mapper.Domain2Repo(productType);
            dbContext.UpdateRange(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }
    }
}
