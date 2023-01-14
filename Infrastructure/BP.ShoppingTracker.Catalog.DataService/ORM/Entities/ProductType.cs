using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities
{
    [Table("ProductType")]
    public partial class ProductType
    {
        public ProductType()
        {
            InverseParentFKNavigation = new HashSet<ProductType>();
            Products = new HashSet<Product>();
        }

        [Key]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; }
        public Guid ProductCategoryFK { get; set; }
        public Guid? ParentFK { get; set; }
        [Required]
        public bool? Active { get; set; }

        [ForeignKey("ParentFK")]
        [InverseProperty("InverseParentFKNavigation")]
        public virtual ProductType ParentFKNavigation { get; set; }
        [ForeignKey("ProductCategoryFK")]
        [InverseProperty("ProductTypes")]
        public virtual ProductCategory ProductCategoryFKNavigation { get; set; } = null!;
        [InverseProperty("ParentFKNavigation")]
        public virtual ICollection<ProductType> InverseParentFKNavigation { get; set; }
        [InverseProperty("ProductTypeFKNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
