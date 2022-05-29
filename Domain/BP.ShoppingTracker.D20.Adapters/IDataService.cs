using BP.ShoppingTracker.D10.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D20.Adapters
{
    public interface IDataService
    {
        #region CREATE
        Task CreateAsync(ProductCategory productCategory);
        Task CreateAsync(ProductType productType);
        Task CreateAsync(FormatType formatType);
        Task CreateAsync(MeasureType measureType);
        Task CreateAsync(Format format);
        Task CreateAsync(Company company);
        Task CreateAsync(Brand brand);
        Task CreateAsync(Product product);
        Task CreateAsync(IEnumerable<ProductCategory> productCategory);
        Task CreateAsync(IEnumerable<ProductType> productType);
        Task CreateAsync(IEnumerable<FormatType> formatType);
        Task CreateAsync(IEnumerable<MeasureType> measureType);
        Task CreateAsync(IEnumerable<Format> format);
        Task CreateAsync(IEnumerable<Company> company);
        Task CreateAsync(IEnumerable<Brand> brand);
        Task CreateAsync(IEnumerable<Product> product);
        #endregion

        #region READ
        Task<IEnumerable<ProductCategory>> ReadProductCategories();
        Task<ProductType> ReadProductType(Guid Id, bool IncludeParent = false, bool IncludeChildren = false);
        Task<IEnumerable<ProductType>> ReadProductTypes(bool includeCategory = true);
        Task<IEnumerable<ProductType>> ReadProductTypes(string SearchName, bool IncludeCategory = true, bool ReturnHierarchy = false);
        Task<IEnumerable<MeasureType>> ReadMeasureTypes();
        Task<IEnumerable<FormatType>> ReadFormatTypes(string SearchName = "");
        Task<Format> ReadFormat(Guid Id, bool IncludeParent = true);
        Task<IEnumerable<Format>> ReadFormats();
        #endregion

        #region UPDATE
        Task<IEnumerable<ProductType>> UpdateProductTypes(IEnumerable<ProductType> productType);
        #endregion

        #region DELETE

        #endregion
    }
}
