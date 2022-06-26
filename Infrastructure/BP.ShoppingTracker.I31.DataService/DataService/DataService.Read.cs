using BP.ShoppingTracker.D10.Models.Products;
using BP.ShoppingTracker.D20.Adapters;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.I31.DataService
{
    public partial class DataService : IDataService
    {
        public async Task<IEnumerable<ProductCategory>> ReadProductCategories()
        {
            var query = await dbContext.ProductCategories.AsNoTracking().ToListAsync();
            return mapper.Repo2Domain(query);
        }

        public async Task<ProductType> ReadProductType(Guid id, bool includeParent = false, bool includeChildren = false)
        {
            var query = dbContext.ProductTypes.AsNoTracking();
            if (includeParent)
                query = query.Include(pt => pt.ParentFKNavigation);
            if (includeChildren)
                query = query.Include(pt => pt.InverseParentFKNavigation);
            query = query.Include(pt => pt.ProductCategoryFKNavigation);

            var result = await query.SingleOrDefaultAsync(pt => pt.ID == id);
            var returned = mapper.Repo2Domain(result);
            if (returned is not null)
            {
                returned.ProductCategory = mapper.Repo2Domain(result.ProductCategoryFKNavigation);
                returned.Children = mapper.Repo2Domain(result.InverseParentFKNavigation);
                returned.Parent = mapper.Repo2Domain(result.ParentFKNavigation);
            }
            return returned;
        }
        public async Task<IEnumerable<ProductType>> ReadProductTypes(bool includeCategory = true) => await this.ReadProductTypes(string.Empty, includeCategory);
        public async Task<IEnumerable<ProductType>> ReadProductTypes(string searchName, bool includeCategory = true, bool returnHierarchy = false, bool onlyRootLevel = false)
        {
            List<ProductType> result = new List<ProductType>();
            var query = dbContext.ProductTypes.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(searchName))
                query = query.Where(pt => searchName.ToUpperInvariant().Contains(pt.Name.ToUpperInvariant()));
            if (onlyRootLevel)
                query = query.Where(pt => pt.ParentFK == null);
            if (returnHierarchy && !onlyRootLevel)
                query = query.Include(pt => pt.InverseParentFKNavigation);

            //Fill 
            //TODO-QUitar repetidos cuando son hijos
            var resultDb = await query.ToListAsync();
            foreach (var item in resultDb)
            {
                var type = mapper.Repo2Domain(item);
                if (returnHierarchy)
                    type.Children = mapper.Repo2Domain(resultDb.Where(child => type.Id == child.ParentFK));
                result.Add(type);
            }
            if (returnHierarchy)
            {
                var remove = result.Where(r => r.ParentFK != null).ToList();
                foreach (var item in remove)
                    result.Remove(item);
            }


            //Fill optional fields
            if (includeCategory)
            {
                var categories = await this.ReadProductCategories();
                foreach (var pt in result)
                    pt.ProductCategory = categories.Where(c => c.Id == pt.ProductCategoryFK).FirstOrDefault();
                if (returnHierarchy)
                    foreach (var pt in result.SelectMany(pt => pt.Children))
                        pt.ProductCategory = categories.Where(c => c.Id == pt.ProductCategoryFK).FirstOrDefault();
            }
            return result;
        }

        public async Task<IEnumerable<MeasureType>> ReadMeasureTypes()
        {
            var query = await dbContext.MeasureTypes.AsNoTracking()
                .ToListAsync();
            return mapper.Repo2Domain(query);
        }

        public async Task<IEnumerable<FormatType>> ReadFormatTypes(string searchName = "")
        {
            List<FormatType> response = new List<FormatType>();
            var query = dbContext.FormatTypes.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(searchName))
                query = query.Where(ft => ft.Name.ToUpperInvariant().Contains(searchName.ToUpperInvariant()));

            var result = await query.ToListAsync();
            foreach (var item in result)
                response.Add(mapper.Repo2Domain(item));

            return response;
        }

        public async Task<Format> ReadFormat(Guid id, Guid idDerived = default(Guid))
        {
            Format format = new Format();
            var query = await dbContext.CombinedFormats.AsNoTracking()
                .Include(cf => cf.MainFormatFKNavigation).ThenInclude(f => f.MeasureTypeFKNavigation)
                .Include(cf => cf.MainFormatFKNavigation).ThenInclude(f => f.FormatTypeFKNavigation)
                .Include(cf => cf.DerivedFormatFKNavigation).ThenInclude(f => f.MeasureTypeFKNavigation)
                .Include(cf => cf.DerivedFormatFKNavigation).ThenInclude(f => f.FormatTypeFKNavigation)
                .SingleOrDefaultAsync(cf => cf.MainFormatFK == id && cf.DerivedFormatFK == idDerived);

            format = mapper.MapCombinedFormat(query);
            return format;
        }
        public async Task<IEnumerable<Format>> ReadFormats()
        {
            List<Format> formats = new List<Format>();
            var query = dbContext.CombinedFormats.AsNoTracking()
                .Include(cf => cf.MainFormatFKNavigation).ThenInclude(f => f.MeasureTypeFKNavigation)
                .Include(cf => cf.MainFormatFKNavigation).ThenInclude(f => f.FormatTypeFKNavigation)
                .Include(cf => cf.DerivedFormatFKNavigation).ThenInclude(f => f.MeasureTypeFKNavigation)
                .Include(cf => cf.DerivedFormatFKNavigation).ThenInclude(f => f.FormatTypeFKNavigation);

            var result = await query.ToListAsync();

            formats = mapper.MapCombinedFormat(result).ToList();
            return formats;
        }

        public async Task<Company> ReadCompany(Guid id)
        {
            Company company = new Company();
            var result = await dbContext.Companies.AsNoTracking()
                .Include(c => c.Brands)
                .SingleOrDefaultAsync();

            company = mapper.Repo2Domain(result);
            if (company is not null)
                company.Brands = mapper.Repo2Domain(result.Brands);
            return company;
        }
        public async Task<IEnumerable<Company>> ReadCompanies(bool includeBrands = false)
        {
            List<Company> companies = new List<Company>();
            var query = dbContext.Companies.AsNoTracking();
            if (includeBrands)
                query = query.Include(c => c.Brands);

            var response = await query.ToListAsync();
            foreach (var companyDb in response)
            {
                var company = mapper.Repo2Domain(companyDb);
                if (includeBrands)
                    company.Brands = mapper.Repo2Domain(companyDb.Brands);
            }
            return companies;
        }

        public async Task<Brand> ReadBrand(Guid id)
        {
            Brand brand = new Brand();
            var result = await dbContext.Brands.AsNoTracking()
                .Include(b => b.CompanyFKNavigation)
                .SingleOrDefaultAsync(b => b.ID == id);
            brand = mapper.Repo2Domain(result);
            if (brand is not null)
                brand.Company = mapper.Repo2Domain(result.CompanyFKNavigation);
            return brand;
        }
        public async Task<IEnumerable<Brand>> ReadBrands(string searchName = "", bool includeCompany = true)
        {
            List<Brand> brands = new List<Brand>();
            var query = dbContext.Brands.AsNoTracking();
            if (includeCompany)
                query = query.Include(c => c.CompanyFKNavigation);
            if (!string.IsNullOrWhiteSpace(searchName))
                query = query.Where(b => b.Name.ToUpperInvariant().Contains(searchName.ToUpperInvariant()));

            var result = await query.ToListAsync();
            foreach (var brandDB in result)
            {
                var brand = mapper.Repo2Domain(brandDB);
                if (includeCompany)
                    brand.Company = mapper.Repo2Domain(brandDB.CompanyFKNavigation);
                brands.Add(brand);
            }
            return brands;
        }




    }
}
