using BP.ShoppingTracker.D10.Models.Products;
using BP.ShoppingTracker.D20.Adapters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService
{
    public partial class DataService : IDataService
    {
        public async Task<IEnumerable<ProductCategory>> ReadProductCategories()
        {
            var query = await dbContext.ProductCategories.AsNoTracking().ToListAsync();
            return mapper.Repo2Domain(query);
        }

        public async Task<IEnumerable<ProductType>> ReadProductTypes(bool includeCategory = true)
        {
            List<ProductType> result = new List<ProductType>();
            var query = dbContext.ProductTypes.AsNoTracking().Include(pt => pt.ProductCategoryFKNavigation);
            foreach (var item in query)
                result.Add(mapper.Repo2Domain(item));
            if (includeCategory)
            {

                var categories = await this.ReadProductCategories();
                foreach (var pt in result)
                {
                    pt.ProductCategory = categories.Where(c => c.Id == pt.ProductCategoryFK).FirstOrDefault();
                }
            }
            return result;
        }
    }
}
