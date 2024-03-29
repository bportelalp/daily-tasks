﻿using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Adapters.Catalogue.Mapping;
using BP.ShoppingTracker.Adapters.Catalogue.ORM.Context;
using BP.ShoppingTracker.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Catalogue.DataService
{
    public partial class CatalogueDataService : ICatalogueService
    {
        private readonly ShoppingTrackerContext dbContext;
        private readonly Mapper mapper = new Mapper();

        public CatalogueDataService(ShoppingTrackerContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        public async Task CreateAsync(ProductCategory productCategory)
        {
            var row = mapper.Domain2Repo(productCategory);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(ProductType productType)
        {
            var row = mapper.Domain2Repo(productType);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(FormatType formatType)
        {
            var row = mapper.Domain2Repo(formatType);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(MeasureType measureType)
        {
            var row = mapper.Domain2Repo(measureType);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Format format, bool updateMainFormat = true, bool updateDerivedFormat = false)
        {
            ORM.Entities.CombinedFormat composed = mapper.Domain2Repo(format.ComposedId);
            ORM.Entities.Format mainFormat = mapper.Domain2Repo(format);
            ORM.Entities.Format derivedFormat = mapper.Domain2Repo(format.DerivedFormat);
            if (updateMainFormat && mainFormat is not null)
            {
                if (dbContext.Formats.Any(f => f.ID == mainFormat.ID))
                    dbContext.Entry(mainFormat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                else
                    dbContext.Add(mainFormat);
            }
            if (updateDerivedFormat && derivedFormat is not null)
            {
                if (dbContext.Formats.Any(f => f.ID == derivedFormat.ID))
                    dbContext.Entry(derivedFormat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                else
                    dbContext.Add(derivedFormat);
            }
            dbContext.Add(composed);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Tuple<Guid, Guid> CombinedId)
        {
            var combined = mapper.Domain2Repo(CombinedId);
            combined.Active = true;
            dbContext.Add(combined);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Company company)
        {
            var row = mapper.Domain2Repo(company);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Brand brand)
        {
            var row = mapper.Domain2Repo(brand);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Product product)
        {
            var row = mapper.Domain2Repo(product);
            dbContext.Add(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<ProductCategory> productCategory)
        {
            var row = mapper.Domain2Repo(productCategory);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<ProductType> productType)
        {
            var row = mapper.Domain2Repo(productType);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<FormatType> formatType)
        {
            var row = mapper.Domain2Repo(formatType);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<MeasureType> measureType)
        {
            var row = mapper.Domain2Repo(measureType);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<Format> format)
        {
            var row = mapper.Domain2Repo(format);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<Company> company)
        {
            var row = mapper.Domain2Repo(company);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<Brand> brand)
        {
            var row = mapper.Domain2Repo(brand);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(IEnumerable<Product> product)
        {
            var row = mapper.Domain2Repo(product);
            dbContext.AddRange(row);
            await dbContext.SaveChangesAsync();
        }



    }
}
