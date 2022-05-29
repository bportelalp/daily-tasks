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

        public async Task<ProductType> ReadProductType(Guid Id, bool IncludeParent = false, bool IncludeChildren = false)
        {
            var query = dbContext.ProductTypes.AsNoTracking();
            if (IncludeParent)
                query = query.Include(pt => pt.ParentFKNavigation);
            if (IncludeChildren)
                query = query.Include(pt => pt.InverseParentFKNavigation);
            query = query.Include(pt => pt.ProductCategoryFKNavigation);

            var result = await query.SingleOrDefaultAsync(pt => pt.ID == Id);
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
        public async Task<IEnumerable<ProductType>> ReadProductTypes(string SearchName, bool IncludeCategory = true, bool ReturnHierarchy = false)
        {
            List<ProductType> result = new List<ProductType>();
            var query = dbContext.ProductTypes.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query.Where(pt => SearchName.ToUpperInvariant().Contains(pt.Name.ToUpperInvariant()));
            if (ReturnHierarchy)
                query = query.Include(pt => pt.InverseParentFKNavigation);

            //Fill 
            //TODO-QUitar repetidos cuando son hijos
            var resultDb = await query.ToListAsync();
            foreach (var item in resultDb)
            {
                var type = mapper.Repo2Domain(item);
                if (ReturnHierarchy)
                    type.Children = mapper.Repo2Domain(resultDb.Where(child => type.Id == child.ParentFK));
                result.Add(type);
            }

            //Fill optional fields
            if (IncludeCategory)
            {
                var categories = await this.ReadProductCategories();
                foreach (var pt in result)
                    pt.ProductCategory = categories.Where(c => c.Id == pt.ProductCategoryFK).FirstOrDefault();
                if (ReturnHierarchy)
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

        public async Task<IEnumerable<FormatType>> ReadFormatTypes(string SearchName = "")
        {
            List<FormatType> response = new List<FormatType>();
            var query = dbContext.FormatTypes.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query.Where(ft => ft.Name.ToUpperInvariant().Contains(SearchName.ToUpperInvariant()));

            var result = await query.ToListAsync();
            foreach (var item in result)
                response.Add(mapper.Repo2Domain(item));

            return response;
        }

        public async Task<Format> ReadFormat(Guid Id, bool IncludeParent = true)
        {
            Format format = new Format();
            var query = dbContext.Formats.AsNoTracking();
            //if (IncludeParent)
            //    query = query.Include(f => f.ParentFKNavigation).ThenInclude(f2 => f2.MeasureTypeFKNavigation).Include(f2 => f2.FormatTypeFKNavigation);
            query = query.Include(f => f.MeasureTypeFKNavigation).Include(f => f.FormatTypeFKNavigation);

            var result = await query.SingleOrDefaultAsync(f => f.ID == Id);

            format = mapper.Repo2Domain(result);
            if (format is not null)
            {
                format.FormatType = mapper.Repo2Domain(result.FormatTypeFKNavigation);
                format.MeasureType = mapper.Repo2Domain(result.MeasureTypeFKNavigation);
                if (IncludeParent && format.ParentFK != default(Guid))
                {
                    var parentBuilded = await this.ReadFormat((Guid)format.ParentFK, false);
                    format.MainFormat = parentBuilded;
                }
            }
            return format;
        }

        public async Task<IEnumerable<Format>> ReadFormats()
        {
            List<Format> formats = new List<Format>();
            var query = dbContext.Formats.AsNoTracking().Include(f => f.MeasureTypeFKNavigation).Include(f => f.FormatTypeFKNavigation);

            var result = await query.ToListAsync();
            //TODO- está mal
            //rellenar aquellos derivados
            foreach (var item in result)
            {
                var format = mapper.Repo2Domain(item);
                format.MeasureType = mapper.Repo2Domain(item.MeasureTypeFKNavigation);
                format.FormatType = mapper.Repo2Domain(item.FormatTypeFKNavigation);
                var parentDB = result.FirstOrDefault(f => f.ID == format.ParentFK);
                if (parentDB is not null)
                {
                    var parent = mapper.Repo2Domain(parentDB);
                    parent.MeasureType = mapper.Repo2Domain(parentDB.MeasureTypeFKNavigation);
                    parent.FormatType = mapper.Repo2Domain(parentDB.FormatTypeFKNavigation);
                    format.MainFormat = parent;
                }
                formats.Add(format);
            }
            return formats;
        }

    }
}
