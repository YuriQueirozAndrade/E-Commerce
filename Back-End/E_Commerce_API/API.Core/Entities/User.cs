#nullable enable
using E_Commerce_API.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Core.Entities
{
  public class User : IdentityUser, IDeletedEntity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Deleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public virtual List<Address> Addresses { get; set; }
    public virtual List<Order> Orders { get; set; }
  }
}
