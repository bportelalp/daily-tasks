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
        Task CreateAsync(Format format, bool updateMainFormat = true, bool updateDerivedFormat = false);
        Task CreateAsync(Tuple<Guid, Guid> CombinedId);
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
        Task<ProductType> ReadProductType(Guid id, bool includeParent = false, bool includeChildren = false);
        Task<IEnumerable<ProductType>> ReadProductTypes(bool includeCategory = true);
        Task<IEnumerable<ProductType>> ReadProductTypes(string searchName, bool includeCategory = true, bool returnHierarchy = false, bool onlyRootLevel = false);
        Task<IEnumerable<MeasureType>> ReadMeasureTypes();
        Task<IEnumerable<FormatType>> ReadFormatTypes(string SearchName = "");
        Task<Format> ReadFormat(Guid id, Guid id2 = default(Guid));
        Task<IEnumerable<Format>> ReadFormats();
        Task<Company> ReadCompany(Guid id);
        Task<IEnumerable<Company>> ReadCompanies(bool includeBrands = false);
        Task<Brand> ReadBrand(Guid id);
        Task<IEnumerable<Brand>> ReadBrands(string searchName = "", bool includeCompany = true);

        //Task<IEnumerable<Product>> ReadProducts(string searchName = "");
        #endregion

        #region UPDATE
        Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
        Task<ProductType> UpdateAsync(ProductType productType);
        Task<Company> UpdateAsync(Company company);
        Task<Brand> UpdateAsync(Brand brand);
        Task<IEnumerable<ProductType>> UpdateAsync(IEnumerable<ProductType> productType);
        Task<Tuple<Guid, Guid>> UpdateFormatCombination(Guid mainFormatId, Guid derivedFormatId, bool active = true);
        #endregion

        #region DELETE
        Task DeleteAsync(ProductCategory productCategory);
        Task DeleteAsync(ProductType productType);
        Task DeleteAsync(Company company);
        Task DeleteAsync(Brand brand);
        #endregion
    }
}
