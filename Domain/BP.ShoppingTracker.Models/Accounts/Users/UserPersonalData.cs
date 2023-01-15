using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Accounts.Users
{
    public class UserPersonalData
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Identification { get; set; } = null!; 
        public IEnumerable<Address> Addresses { get; set; } = Enumerable.Empty<Address>();
    }
}
