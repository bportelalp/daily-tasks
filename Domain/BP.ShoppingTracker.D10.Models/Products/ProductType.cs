using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D10.Models.Products
{
    public class ProductType : Base.EntityBase
    {
        public Guid ProductCategoryFK { get; set; }
        public Guid? ParentFK { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public ProductType Parent { get; set; }
        public List<ProductType> Children { get; set; }
        public bool HasParent => Parent is null;
        public bool HasProductCategory => ProductCategory is null;
        public bool HasChildren => Children is null || Children.Any();
    }
}
