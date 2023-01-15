using BP.ShoppingTracker.Models.Accounts;
using BP.ShoppingTracker.Models.Accounts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adaptables
{
    public interface IIdentityService
    {
        public Task<UserPersonalData?> GetUserPersonalData(Guid userId);
        public Task<UserPersonalData> CreateUserPersonalData(UserPersonalData data);
        public Task<UserPersonalData> UpdateUserPersonalData();
    }
}
