using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities
{
    /// <summary>
    /// Categoría del tipo de producto: Alimentación, perfumería etc
    /// </summary>
    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductTypes = new HashSet<ProductType>();
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public bool? Active { get; set; }

        [InverseProperty("ProductCategoryFKNavigation")]
        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
