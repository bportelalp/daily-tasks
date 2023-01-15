using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Products
{
    public class Brand : Base.EntityBase
    {
        public Guid? CompanyFK { get; set; }
        public Company Company { get; set; } = null!;
    }
}
