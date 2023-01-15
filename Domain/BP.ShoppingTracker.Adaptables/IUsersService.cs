using BP.ShoppingTracker.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adaptables
{
    public interface IIdentityService
    {
        public Task<RoleDTO> GetRoles();
    }
}
