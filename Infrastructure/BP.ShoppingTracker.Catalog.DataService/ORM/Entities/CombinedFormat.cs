using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities
{
    [Table("CombinedFormat")]
    public partial class CombinedFormat
    {
        public CombinedFormat()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public Guid MainFormatFK { get; set; }
        [Required]
        public Guid DerivedFormatFK { get; set; }

        [Required]
        public bool? Active { get; set; }

        [ForeignKey("DerivedFormatFK")]
        [InverseProperty("CombinedFormatDerivedFormatFKNavigations")]
        public virtual Format DerivedFormatFKNavigation { get; set; } = null!;
        [ForeignKey("MainFormatFK")]
        [InverseProperty("CombinedFormatMainFormatFKNavigations")]
        public virtual Format MainFormatFKNavigation { get; set; } = null!;
        [InverseProperty("FormatFKNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
