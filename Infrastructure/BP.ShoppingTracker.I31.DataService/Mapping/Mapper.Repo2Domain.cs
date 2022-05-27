using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.I31.DataService.Mapping
{
    internal partial class Mapper : MapperBase
    {
        internal IEnumerable<I30.Persistence.Entities.ProductCategory> Domain2Repo(IEnumerable<D10.Models.Products.ProductCategory> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.ProductType> Domain2Repo(IEnumerable<D10.Models.Products.ProductType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.MeasureType> Domain2Repo(IEnumerable<D10.Models.Products.MeasureType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.FormatType> Domain2Repo(IEnumerable<D10.Models.Products.FormatType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.Format> Domain2Repo(IEnumerable<D10.Models.Products.Format> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.Brand> Domain2Repo(IEnumerable<D10.Models.Products.Brand> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.Company> Domain2Repo(IEnumerable<D10.Models.Products.Company> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<I30.Persistence.Entities.Product> Domain2Repo(IEnumerable<D10.Models.Products.Product> domain) => MapList(domain, Domain2Repo);

        internal I30.Persistence.Entities.ProductCategory Domain2Repo(D10.Models.Products.ProductCategory domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.ProductCategory row = new I30.Persistence.Entities.ProductCategory()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal I30.Persistence.Entities.ProductType Domain2Repo(D10.Models.Products.ProductType domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.ProductType row = new I30.Persistence.Entities.ProductType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active,
                ProductCategoryFK = domain.ProductCategoryFK,
                ParentFK = domain.ParentFK,
            };
            return row;
        }

        internal I30.Persistence.Entities.MeasureType Domain2Repo(D10.Models.Products.MeasureType domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.MeasureType row = new I30.Persistence.Entities.MeasureType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Unit = domain.Unit,
                ScaleFactorSI = domain.ScaleFactorSI
            };
            return row;
        }

        internal I30.Persistence.Entities.FormatType Domain2Repo(D10.Models.Products.FormatType domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.FormatType row = new I30.Persistence.Entities.FormatType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal I30.Persistence.Entities.Format Domain2Repo(D10.Models.Products.Format domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.Format row = new I30.Persistence.Entities.Format()
            {
                ID = domain.Id,
                FormatTypeFK = domain.FormatTypeFK,
                MeasureTypeFK = domain.MeasureTypeFK,
                Value = domain.Value,
                Active = domain.Active
            };
            return row;
        }

        internal I30.Persistence.Entities.Brand Domain2Repo(D10.Models.Products.Brand domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.Brand row = new I30.Persistence.Entities.Brand()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                CompanyFK = domain.CompanyFK
            };
            return row;
        }

        internal I30.Persistence.Entities.Company Domain2Repo(D10.Models.Products.Company domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.Company row = new I30.Persistence.Entities.Company()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description
            };
            return row;
        }

        internal I30.Persistence.Entities.Product Domain2Repo(D10.Models.Products.Product domain)
        {
            if (domain is null) return null;
            I30.Persistence.Entities.Product row = new I30.Persistence.Entities.Product()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                ProductTypeFK = domain.ProductTypeFK,
                FormatFK = domain.FormatFK,
                BrandFK = domain.BrandFK,
                BarCode = domain.BarCode,
                Active = domain.Active,
            };
            return row;
        }
    }
}
