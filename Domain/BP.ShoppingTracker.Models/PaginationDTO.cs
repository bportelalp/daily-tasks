using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models
{
    public class PaginationDTO<T>
    {
        public int Start { get; set; }
        public int Amount { get; set; }
        public int End => Start + Amount;
        public int? Total { get; set; }

        public IEnumerable<T> Items { get; set; } = null!;

    }
}
