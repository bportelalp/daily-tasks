using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Products
{
    public class ProductType : Base.EntityBase
    {
        public Guid ProductCategoryFK { get; set; }
        public Guid? ParentFK { get; set; }

        public ProductCategory ProductCategory { get; set; } = null!;
        public ProductType Parent { get; set; } = null!;
        public IEnumerable<ProductType> Children { get; set; } = null!;
        public bool HasParent => Parent is null;
        public bool HasProductCategory => ProductCategory is null;
        public bool HasChildren => Children is null || Children.Any();

        public override string ToString() => Name + " - " + (ProductCategory == null ? "" : $"({ProductCategory?.Description}) - ") + Id;
    }
}
