using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService.Mapping
{
    internal partial class Mapper : MapperBase
    {

        internal IEnumerable<D10.Models.Products.ProductCategory> Repo2Domain(IEnumerable<I30.Persistence.Entities.ProductCategory> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.ProductType> Repo2Domain(IEnumerable<I30.Persistence.Entities.ProductType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.MeasureType> Repo2Domain(IEnumerable<I30.Persistence.Entities.MeasureType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.FormatType> Repo2Domain(IEnumerable<I30.Persistence.Entities.FormatType> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.Format> Repo2Domain(IEnumerable<I30.Persistence.Entities.Format> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.Brand> Repo2Domain(IEnumerable<I30.Persistence.Entities.Brand> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.Company> Repo2Domain(IEnumerable<I30.Persistence.Entities.Company> domain) => MapList(domain, Repo2Domain);
        internal IEnumerable<D10.Models.Products.Product> Repo2Domain(IEnumerable<I30.Persistence.Entities.Product> domain) => MapList(domain, Repo2Domain);

        internal D10.Models.Products.ProductCategory Repo2Domain(I30.Persistence.Entities.ProductCategory row)
        {
            if (row is null) return null;
            D10.Models.Products.ProductCategory domain = new D10.Models.Products.ProductCategory()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Active = row.Active
            };
            return domain;
        }

        internal D10.Models.Products.ProductType Repo2Domain(I30.Persistence.Entities.ProductType row)
        {
            if (row is null) return null;
            D10.Models.Products.ProductType domain = new D10.Models.Products.ProductType()
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

        internal D10.Models.Products.MeasureType Repo2Domain(I30.Persistence.Entities.MeasureType row)
        {
            if (row is null) return null;
            D10.Models.Products.MeasureType domain = new D10.Models.Products.MeasureType()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Unit = row.Unit,
                ScaleFactorSI = row.ScaleFactorSI
            };
            return domain;
        }

        internal D10.Models.Products.FormatType Repo2Domain(I30.Persistence.Entities.FormatType row)
        {
            if (row is null) return null;
            D10.Models.Products.FormatType domain = new D10.Models.Products.FormatType()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                Active = row.Active
            };
            return domain;
        }

        internal D10.Models.Products.Format Repo2Domain(I30.Persistence.Entities.Format row)
        {
            if (row is null) return null;
            D10.Models.Products.Format domain = new D10.Models.Products.Format()
            {
                Id = row.ID,
                FormatTypeFK = row.FormatTypeFK,
                MeasureTypeFK = row.MeasureTypeFK,
                Value = row.Value,
                Active = row.Active
            };
            return domain;
        }

        internal D10.Models.Products.Brand Repo2Domain(I30.Persistence.Entities.Brand row)
        {
            if (row is null) return null;
            D10.Models.Products.Brand domain = new D10.Models.Products.Brand()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description,
                CompanyFK = row.CompanyFK
            };
            return domain;
        }

        internal D10.Models.Products.Company Repo2Domain(I30.Persistence.Entities.Company row)
        {
            if (row is null) return null;
            D10.Models.Products.Company domain = new D10.Models.Products.Company()
            {
                Id = row.ID,
                Name = row.Name,
                Description = row.Description
            };
            return domain;
        }

        internal D10.Models.Products.Product Repo2Domain(I30.Persistence.Entities.Product row)
        {
            if (row is null) return null;
            D10.Models.Products.Product domain = new D10.Models.Products.Product()
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
