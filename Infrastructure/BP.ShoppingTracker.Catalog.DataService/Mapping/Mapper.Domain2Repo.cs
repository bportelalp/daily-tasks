using BP.ShoppingTracker.Adapters.Catalogue.Mapping;
using BP.ShoppingTracker.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Catalogue.Mapping
{
    internal partial class Mapper : MapperBase
    {
        internal IEnumerable<ORM.Entities.ProductCategory> Domain2Repo(IEnumerable<Models.Products.ProductCategory> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.ProductType> Domain2Repo(IEnumerable<Models.Products.ProductType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.MeasureType> Domain2Repo(IEnumerable<Models.Products.MeasureType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.FormatType> Domain2Repo(IEnumerable<Models.Products.FormatType> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.Format> Domain2Repo(IEnumerable<Models.Products.Format> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.Brand> Domain2Repo(IEnumerable<Models.Products.Brand> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.Company> Domain2Repo(IEnumerable<Models.Products.Company> domain) => MapList(domain, Domain2Repo);
        internal IEnumerable<ORM.Entities.Product> Domain2Repo(IEnumerable<Models.Products.Product> domain) => MapList(domain, Domain2Repo);

        internal ORM.Entities.ProductCategory Domain2Repo(Models.Products.ProductCategory domain)
        {
            if (domain is null) return null;
            ORM.Entities.ProductCategory row = new ORM.Entities.ProductCategory()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal ORM.Entities.ProductType Domain2Repo(Models.Products.ProductType domain)
        {
            if (domain is null) return null;
            ORM.Entities.ProductType row = new ORM.Entities.ProductType()
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

        internal ORM.Entities.MeasureType Domain2Repo(Models.Products.MeasureType domain)
        {
            if (domain is null) return null;
            ORM.Entities.MeasureType row = new ORM.Entities.MeasureType()
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

        internal ORM.Entities.FormatType Domain2Repo(Models.Products.FormatType domain)
        {
            if (domain is null) return null;
            ORM.Entities.FormatType row = new ORM.Entities.FormatType()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Active = domain.Active
            };
            return row;
        }

        internal ORM.Entities.Format Domain2Repo(Models.Products.Format domain)
        {
            if (domain is null) return null;
            ORM.Entities.Format row = new ORM.Entities.Format()
            {
                ID = domain.Id,
                FormatTypeFK = domain.FormatTypeFK,
                MeasureTypeFK = domain.MeasureTypeFK,
                Value = domain.Value,
                Active = domain.Active
            };
            return row;
        }

        internal ORM.Entities.CombinedFormat Domain2Repo(Tuple<Guid,Guid> ComposedId)
        {
            if (ComposedId is null) return null;
            ORM.Entities.CombinedFormat row = new ORM.Entities.CombinedFormat()
            {
                MainFormatFK = ComposedId.Item1,
                DerivedFormatFK = ComposedId.Item2
            };
            return row;
        }

        internal ORM.Entities.Brand Domain2Repo(Models.Products.Brand domain)
        {
            if (domain is null) return null;
            ORM.Entities.Brand row = new ORM.Entities.Brand()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                CompanyFK = domain.CompanyFK
            };
            return row;
        }

        internal ORM.Entities.Company Domain2Repo(Models.Products.Company domain)
        {
            if (domain is null) return null;
            ORM.Entities.Company row = new ORM.Entities.Company()
            {
                ID = domain.Id,
                Name = domain.Name,
                Description = domain.Description
            };
            return row;
        }

        internal ORM.Entities.Product Domain2Repo(Models.Products.Product domain)
        {
            if (domain is null) return null;
            ORM.Entities.Product row = new ORM.Entities.Product()
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
