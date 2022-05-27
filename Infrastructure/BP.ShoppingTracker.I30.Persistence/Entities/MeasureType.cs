using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.I30.Persistence.Entities
{
    [Table("MeasureType")]
    public partial class MeasureType
    {
        public MeasureType()
        {
            Formats = new HashSet<Format>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; } = null!;
        [StringLength(10)]
        public string Unit { get; set; } = null!;
        public int ScaleFactorSI { get; set; }

        [InverseProperty("MeasureTypeFKNavigation")]
        public virtual ICollection<Format> Formats { get; set; }
    }
}
