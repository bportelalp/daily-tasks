using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            CostEvolutions = new HashSet<CostEvolution>();
        }

        [Key]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; }
        public Guid ProductTypeFK { get; set; }
        public Guid FormatFK1 { get; set; }
        public Guid FormatFK2 { get; set; }
        public Guid BrandFK { get; set; }
        public int? BarCode { get; set; }
        [Required]
        public bool? Active { get; set; }

        [ForeignKey("BrandFK")]
        [InverseProperty("Products")]
        public virtual Brand BrandFKNavigation { get; set; } = null!;
        [ForeignKey("FormatFK1, FormatFK2")]
        [InverseProperty("Products")]
        public virtual CombinedFormat FormatFKNavigation { get; set; } = null!;
        [ForeignKey("ProductTypeFK")]
        [InverseProperty("Products")]
        public virtual ProductType ProductTypeFKNavigation { get; set; } = null!;
        [InverseProperty("ProductFKNavigation")]
        public virtual ICollection<CostEvolution> CostEvolutions { get; set; }
    }
}
