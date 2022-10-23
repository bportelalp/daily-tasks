using BP.ShoppingTracker.DataService.Mapping;
using BP.ShoppingTracker.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.DataService.Mapping
{
    internal partial class Mapper : MapperBase
    {
        internal IEnumerable<Persistence.Entities.ProductCategory> Domain2Repo(IEnumerable<Models.Products.ProductCategory> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.ProductType> Domain2Repo(IEnumerable<Models.Products.ProductType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.MeasureType> Domain2Repo(IEnumerable<Models.Products.MeasureType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.FormatType> Domain2Repo(IEnumerable<Models.Products.FormatType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.Format> Domain2Repo(IEnumerable<Models.Products.Format> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.Brand> Domain2Repo(IEnumerable<Models.Products.Brand> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.Company> Domain2Repo(IEnumerable<Models.Products.Company> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<Persistence.Entities.Product> Domain2Repo(IEnumerable<Models.Products.Product> domain) => MapList(domain, Domain2Repo);

        internal Persistence.Entities.ProductCategory Domain2Repo(Models.Products.ProductCategory domain)
        {
            if (domain is null) return null;
            Persistence.Entities.ProductCategory row = new Persistence.Entities.ProductCategory()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal Persistence.Entities.ProductType Domain2Repo(Models.Products.ProductType domain)
        {
            if (domain is null) return null;
            Persistence.Entities.ProductType row = new Persistence.Entities.ProductType()
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

        internal Persistence.Entities.MeasureType Domain2Repo(Models.Products.MeasureType domain)
        {
            if (domain is null) return null;
            Persistence.Entities.MeasureType row = new Persistence.Entities.MeasureType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Unit = domain.Unit,
                ScaleFactorSI = domain.ScaleFactorSI,
                IsUnitBase = domain.IsUnitBase,
                UnitBaseFK = domain.UnitBaseFK
            };
            return row;
        }

        internal Persistence.Entities.FormatType Domain2Repo(Models.Products.FormatType domain)
        {
            if (domain is null) return null;
            Persistence.Entities.FormatType row = new Persistence.Entities.FormatType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal Persistence.Entities.Format Domain2Repo(Models.Products.Format domain)
        {
            if (domain is null) return null;
            Persistence.Entities.Format row = new Persistence.Entities.Format()
            {
                ID = domain.Id,
                FormatTypeFK = domain.FormatTypeFK,
                MeasureTypeFK = domain.MeasureTypeFK,
                Value = domain.Value,
                Active = domain.Active
            };
            return row;
        }

        internal Persistence.Entities.CombinedFormat Domain2Repo(Tuple<Guid,Guid> ComposedId)
        {
            if (ComposedId is null) return null;
            Persistence.Entities.CombinedFormat row = new Persistence.Entities.CombinedFormat()
            {
                MainFormatFK = ComposedId.Item1,
                DerivedFormatFK = ComposedId.Item2
            };
            return row;
        }

        internal Persistence.Entities.Brand Domain2Repo(Models.Products.Brand domain)
        {
            if (domain is null) return null;
            Persistence.Entities.Brand row = new Persistence.Entities.Brand()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                CompanyFK = domain.CompanyFK
            };
            return row;
        }

        internal Persistence.Entities.Company Domain2Repo(Models.Products.Company domain)
        {
            if (domain is null) return null;
            Persistence.Entities.Company row = new Persistence.Entities.Company()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description
            };
            return row;
        }

        internal Persistence.Entities.Product Domain2Repo(Models.Products.Product domain)
        {
            if (domain is null) return null;
            Persistence.Entities.Product row = new Persistence.Entities.Product()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                ProductTypeFK = domain.ProductTypeFK,
                FormatFK1 = domain.FormatFK1,
                FormatFK2 = domain.FormatFK2,
                BrandFK = domain.BrandFK,
                BarCode = domain.BarCode,
                Active = domain.Active,
            };
            return row;
        }
    }
}
