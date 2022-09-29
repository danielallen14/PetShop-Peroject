using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PetShop.Client.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PetShopClientUser class
public class PetShopClientUser : IdentityUser
{
    public string UserName { get; set; }
    public string LastName { get; set; }

}

