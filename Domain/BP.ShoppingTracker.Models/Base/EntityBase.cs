using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; } = true;
        public bool IsActive { get => Active ?? false; set => Active = value; }
    }
}
