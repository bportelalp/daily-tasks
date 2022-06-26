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
        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            var entity = mapper.Domain2Repo(productCategory);
            dbContext.UpdateRange(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }
        public async Task<ProductType> UpdateProductType(ProductType productType)
        {
            var entity = mapper.Domain2Repo(productType);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<IEnumerable<ProductType>> UpdateProductTypes(IEnumerable<ProductType> productType)
        {
            var entity = mapper.Domain2Repo(productType);
            dbContext.UpdateRange(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<Tuple<Guid,Guid>> UpdateFormatCombination(Guid mainFormatId, Guid derivedFormatId, bool active = true)
        {
            var combined = mapper.Domain2Repo(new Tuple<Guid,Guid>(mainFormatId, derivedFormatId));
            combined.Active = active;
            if (dbContext.CombinedFormats.Any(cf => cf.MainFormatFK == mainFormatId && cf.DerivedFormatFK == derivedFormatId))
                dbContext.Entry(combined).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            else
                dbContext.Add(combined);
            await dbContext.SaveChangesAsync();
            return new Tuple<Guid,Guid>(mainFormatId, derivedFormatId);
        }
    }
}
