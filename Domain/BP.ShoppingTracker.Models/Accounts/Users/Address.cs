using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Accounts.Users
{
    public class Address
    {
        public Guid AddresId { get; set; }
        public string AddressName { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Localty { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string Country { get; set; } = null!; 
    }
}
