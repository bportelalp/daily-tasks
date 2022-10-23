using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Persistence.Entities
{
    [Table("FormatType")]
    public partial class FormatType
    {
        public FormatType()
        {
            Formats = new HashSet<Format>();
        }

        [Key]
        public Guid ID { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        public bool? Active { get; set; }

        [InverseProperty("FormatTypeFKNavigation")]
        public virtual ICollection<Format> Formats { get; set; }
    }
}
