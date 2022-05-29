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
            CombinedFormatDerivedFormatFKNavigations = new HashSet<CombinedFormat>();
            CombinedFormatMainFormatFKNavigations = new HashSet<CombinedFormat>();
        }

        [Key]
        public Guid ID { get; set; }
        public Guid FormatTypeFK { get; set; }
        public int MeasureTypeFK { get; set; }
        public int Value { get; set; }
        [Required]
        public bool? Active { get; set; }

        [ForeignKey("FormatTypeFK")]
        [InverseProperty("Formats")]
        public virtual FormatType FormatTypeFKNavigation { get; set; } = null!;
        [ForeignKey("MeasureTypeFK")]
        [InverseProperty("Formats")]
        public virtual MeasureType MeasureTypeFKNavigation { get; set; } = null!;
        [InverseProperty("DerivedFormatFKNavigation")]
        public virtual ICollection<CombinedFormat> CombinedFormatDerivedFormatFKNavigations { get; set; }
        [InverseProperty("MainFormatFKNavigation")]
        public virtual ICollection<CombinedFormat> CombinedFormatMainFormatFKNavigations { get; set; }
    }
}
