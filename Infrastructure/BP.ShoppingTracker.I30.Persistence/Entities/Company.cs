using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.I30.Persistence.Entities
{
    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            Brands = new HashSet<Brand>();
        }

        [Key]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string? Description { get; set; }

        [InverseProperty("CompanyFKNavigation")]
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
