﻿using BP.ShoppingTracker.D10.Models.Products;
using BP.ShoppingTracker.D20.Adapters;
using BP.ShoppingTracker.I30.Persistence.Context;
using BP.ShoppingTracker.I31.DataService.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService
{
    public partial class DataService : IDataService
    {
        private readonly ShoppingTrackerContext dbContext;
        private readonly Mapper mapper = new Mapper();

        public DataService(ShoppingTrackerContext dbContext)
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

        public async Task CreateAsync(Format format)
        {
            var row = mapper.Domain2Repo(format);
            dbContext.Add(row);
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
