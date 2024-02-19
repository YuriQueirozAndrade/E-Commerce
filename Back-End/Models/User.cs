using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Back_End.Models
{
  public class User : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<Address> Addresses { get; set; }
    public List<Order> Orders { get; set; }
  }
}
