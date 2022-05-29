using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.I30.Persistence.Entities
{
    [Table("Format")]
    public partial class Format
    {
        public Format()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public Guid ID { get; set; }
        public Guid FormatTypeFK { get; set; }
        public int MeasureTypeFK { get; set; }
        public Guid? ParentFK { get; set; }
        public int Value { get; set; }
        [Required]
        public bool? Active { get; set; }

        [ForeignKey("ParentFK")]
        [InverseProperty("InverseParentFKNavigation")]
        public virtual Format? ParentFKNavigation { get; set; }

        [ForeignKey("FormatTypeFK")]
        [InverseProperty("Formats")]
        public virtual FormatType FormatTypeFKNavigation { get; set; } = null!;
        [ForeignKey("MeasureTypeFK")]
        [InverseProperty("Formats")]
        public virtual MeasureType MeasureTypeFKNavigation { get; set; } = null!;
        [InverseProperty("ProductTypeFKNavigation")]
        public virtual ICollection<Product> Products { get; set; }

        [InverseProperty("ParentFKNavigation")]
        public virtual ICollection<Format> InverseParentFKNavigation { get; set; }
    }
}
