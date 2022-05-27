﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.I30.Persistence.Entities
{
    [Table("CostEvolution")]
    public partial class CostEvolution
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ProductFK { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisteredOn { get; set; }
        public double Value { get; set; }
        public bool SalePrice { get; set; }
        public double? RateSale { get; set; }

        [ForeignKey("ProductFK")]
        [InverseProperty("CostEvolutions")]
        public virtual Product ProductFKNavigation { get; set; } = null!;
    }
}
