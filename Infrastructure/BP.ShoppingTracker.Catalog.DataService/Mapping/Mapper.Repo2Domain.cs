using BP.ShoppingTracker.Adapters.Catalogue.Mapping;
using BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Catalogue.Mapping
{
    internal partial class Mapper : MapperBase
    {

        internal IEnumerable<Models.Products.ProductCategory> Repo2Domain(IEnumerable<ProductCategory> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.ProductType> Repo2Domain(IEnumerable<ProductType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.MeasureType> Repo2Domain(IEnumerable<MeasureType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.FormatType> Repo2Domain(IEnumerable<FormatType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.Format> Repo2Domain(IEnumerable<Format> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.Brand> Repo2Domain(IEnumerable<Brand> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.Company> Repo2Domain(IEnumerable<Company> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<Models.Products.Product> Repo2Domain(IEnumerable<Product> domain) => MapList(domain, Repo2Domain);

        internal Models.Products.ProductCategory Repo2Domain(ProductCategory row)
        {
            if (row is null) return null;
            Models.Products.ProductCategory domain = new Models.Products.ProductCategory()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Active = row.Active
            };
            return domain;
        }

        internal Models.Products.ProductType Repo2Domain(ProductType row)
        {
            if (row is null) return null;
            Models.Products.ProductType domain = new Models.Products.ProductType()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Active = row.Active,
                ProductCategoryFK = row.ProductCategoryFK,
                ParentFK = row.ParentFK,
            };
            return domain;
        }

        internal Models.Products.MeasureType Repo2Domain(MeasureType row)
        {
            if (row is null) return null;
            Models.Products.MeasureType domain = new Models.Products.MeasureType()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Unit = row.Unit,
                ScaleFactorSI = row.ScaleFactorSI,
                IsUnitBase = row.IsUnitBase,
                UnitBaseFK = row.UnitBaseFK
            };
            return domain;
        }

        internal Models.Products.FormatType Repo2Domain(FormatType row)
        {
            if (row is null) return null;
            Models.Products.FormatType domain = new Models.Products.FormatType()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Active = row.Active
            };
            return domain;
        }

        internal Models.Products.Format Repo2Domain(Format row)
        {
            if (row is null) return null;
            Models.Products.Format domain = new Models.Products.Format()
            {
                Id = row.ID,
                FormatTypeFK = row.FormatTypeFK,
                MeasureTypeFK = row.MeasureTypeFK,
                Value = row.Value,
                Active = row.Active
            };
            return domain;
        }

        internal Models.Products.Brand Repo2Domain(Brand row)
        {
            if (row is null) return null;
            Models.Products.Brand domain = new Models.Products.Brand()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                CompanyFK = row.CompanyFK
            };
            return domain;
        }

        internal Models.Products.Company Repo2Domain(Company row)
        {
            if (row is null) return null;
            Models.Products.Company domain = new Models.Products.Company()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description
            };
            return domain;
        }

        internal Models.Products.Product Repo2Domain(Product row)
        {
            if (row is null) return null;
            Models.Products.Product domain = new Models.Products.Product()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                ProductTypeFK = row.ProductTypeFK,
                FormatFK1 = row.FormatFK1,
                FormatFK2 = row.FormatFK2,
                BrandFK = row.BrandFK,
                BarCode = row.BarCode,
                Active = row.Active,
            };
            return domain;
        }


    }
}
