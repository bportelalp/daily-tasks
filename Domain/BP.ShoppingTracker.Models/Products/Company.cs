using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Products
{
    public class Company : Base.EntityBase
    {
        public IEnumerable<Brand> Brands { get; set; } = null!;
    }
}
