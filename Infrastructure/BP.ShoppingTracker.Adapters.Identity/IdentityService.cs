using BP.ShoppingTracker.Adaptables;
using BP.ShoppingTracker.Adapters.Identity.ORM.Context;
using BP.ShoppingTracker.Models.Accounts.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly ShoppingTrackerIdentityContext context;
        private readonly ILogger<IdentityService> logger;

        public IdentityService(ShoppingTrackerIdentityContext context, ILogger<IdentityService> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Task<UserPersonalData> CreateUserPersonalData()
        {
            throw new NotImplementedException();
        }

        public async Task<UserPersonalData?> GetUserPersonalData(Guid userId)
        {
            string id = userId.ToString();
            var query = context.AspNetUsers
                .Include(u => u.UserPersonalDatum)
                .Include(u => u.AddressFks)
                .Where(u => u.Id == id);

            var user = await query.SingleOrDefaultAsync();
            if (user is null || user.UserPersonalDatum is null)
                return default;

            var userDto = new UserPersonalData()
            {
                UserId = userId,
                Name = user.UserPersonalDatum.Name,
                Surname = user.UserPersonalDatum.Surname,
                Identification = user.UserPersonalDatum.Identification
            };

            if (user.AddressFks is not null)
            {
                var addresses = new List<Models.Accounts.Users.Address>();
                foreach (var address in user.AddressFks)
                {
                    var addressDto = new Models.Accounts.Users.Address()
                    {
                        AddresId = address.AddressId,
                        AddressName = address.Address1,
                        ZipCode = address.ZipCode,
                        Country = address.Country,
                        Localty = address.Localty,
                        Province = address.Province
                    };
                    addresses.Add(addressDto);
                }
                userDto.Addresses = addresses;
            }

            return userDto;
        }

        public Task<UserPersonalData> UpdateUserPersonalData()
        {
            throw new NotImplementedException();
        }
    }
}
