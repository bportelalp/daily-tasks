using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.DataService
{
    public partial class DataService : IDataService
    {
        public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
        {
            var entity = mapper.Domain2Repo(productCategory);
            dbContext.UpdateRange(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }
        public async Task<ProductType> UpdateAsync(ProductType productType)
        {
            var entity = mapper.Domain2Repo(productType);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<FormatType> UpdateAsync(FormatType formatType)
        {
            var entity = mapper.Domain2Repo(formatType);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            var entity = mapper.Domain2Repo(company);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            var entity = mapper.Domain2Repo(brand);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return mapper.Repo2Domain(entity);
        }

        public async Task<IEnumerable<ProductType>> UpdateAsync(IEnumerable<ProductType> productType)
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
