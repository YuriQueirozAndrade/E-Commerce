#nullable enable
using Microsoft.AspNetCore.Identity;
using Back_End.Models.Interfaces;

namespace Back_End.Models
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
