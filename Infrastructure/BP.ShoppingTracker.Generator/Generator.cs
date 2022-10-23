using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Adapters.Generator.Configuration;
using BP.ShoppingTracker.Models.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Generator
{
    public class Generator : IGenerator
    {
        private readonly IDataService dataService;

        public Generator(IDataService dataService)
        {
            this.dataService = dataService;
        }

        private IEnumerable<ProductCategory> currentCategories { get; set; }
        private IEnumerable<ProductType> currentProductTypes { get; set; }

        public async Task GenerateInitialRows(string configurationfilePath)
        {
            try
            {
                var config = ReadFile(configurationfilePath);
                currentCategories = await dataService.ReadProductCategories();
                currentProductTypes = await dataService.ReadProductTypes();
                List<ProductType> newsProductTypes = new List<ProductType>();
                List<ProductCategory> newsProductCategory = new List<ProductCategory>();
                List<MeasureType> newsMeasureTypes = new List<MeasureType>();

                //Establecer categorías
                foreach (var pt in config.ProductTypesTree)
                {
                    FindCategoriesRecursively(pt, ref newsProductCategory);
                }

                //Establecer Tipos de producto
                foreach (var pt in config.ProductTypesTree)
                {
                    FindProductTypeRecursively(pt, null, ref newsProductTypes, ref newsProductCategory);
                }
                //leer medidas
                newsMeasureTypes = config.MeasureTypes;

                await dataService.CreateAsync(newsProductCategory);
                await dataService.CreateAsync(newsProductTypes);
                await dataService.CreateAsync(newsMeasureTypes);
            }
            catch (Exception ex)
            {

                throw;
            }


        }



        public void FindProductTypeRecursively(Producttype pt, Guid? parentFK, ref List<ProductType> productTypes, ref List<ProductCategory> productCategories)
        {
            var newType = new ProductType();
            if (!productTypes.Any(p => p.Name == pt.Name))
            {
                newType = new ProductType()
                {
                    Id = Guid.NewGuid(),
                    Name = pt.Name,
                    Description = pt.Description,
                    ProductCategoryFK = productCategories.Where(p => p.Name == pt.ProductCategory).FirstOrDefault().Id,
                };
                if (parentFK is not null)
                    newType.ParentFK = parentFK;
                productTypes.Add(newType);
            }
            else
                newType = productTypes.Find(p => p.Name == pt.Name);
            if (pt.ProductTypes is not null)
            {
                foreach (var pt2 in pt.ProductTypes)
                {
                    FindProductTypeRecursively(pt2, newType.Id, ref productTypes, ref productCategories);
                }
            }

        }

        public void FindCategoriesRecursively(Producttype pt, ref List<ProductCategory> productCategories)
        {
            if (!productCategories.Any(pc => pc.Name == pt.ProductCategory))
            {
                productCategories.Add(new ProductCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = pt.ProductCategory
                });
            }
            if (pt.ProductTypes is not null)
            {
                foreach (var pt2 in pt.ProductTypes)
                {
                    FindCategoriesRecursively(pt2, ref productCategories);
                }
            }
        }

        private async Task ManageAdding(List<ProductCategory> productCategories)
        {
            var existingCategories = (await dataService.ReadProductCategories()).ToList();
            var categoriesToAdd = productCategories.Where(c => !existingCategories.Select(e => e.Id).Contains(c.Id));
            await dataService.CreateAsync(categoriesToAdd);
        }

        private async Task ManageAdding(List<ProductType> productTypes)
        {
            var existingTypes = (await dataService.ReadProductTypes()).ToList();
            var typesToAdd = productTypes.Where(c => !existingTypes.Select(e => e.Id).Contains(c.Id)).ToList();
            await dataService.CreateAsync(typesToAdd);
        }

        private ConfigurationFile ReadFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<ConfigurationFile>(json);
                }
            }
        }
    }
}
