using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Persistence.Entities
{
    [Table("Brand")]
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string? Description { get; set; }
        public Guid? CompanyFK { get; set; }

        [ForeignKey("CompanyFK")]
        [InverseProperty("Brands")]
        public virtual Company? CompanyFKNavigation { get; set; }
        [InverseProperty("BrandFKNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
