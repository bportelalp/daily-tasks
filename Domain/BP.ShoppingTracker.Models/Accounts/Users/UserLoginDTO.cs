using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Models.Accounts.Users
{
    public class UserLoginDTO : UserBase
    {

        [Required]
        public string Password { get; set; } = null!;
    }

    public abstract class UserBase
    {

        [Required]
        public string Username { get; set; } = null!;
    }
}
