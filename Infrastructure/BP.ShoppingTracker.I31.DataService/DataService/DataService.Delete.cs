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
        public async Task DeleteProductCategory(ProductCategory productCategory)
        {
            var entity = mapper.Domain2Repo(productCategory);
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductType(ProductType productType)
        {
            var entity = mapper.Domain2Repo(productType);
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
