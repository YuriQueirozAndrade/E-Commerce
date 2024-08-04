#nullable enable
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Application.DTOs
{
    public class LoginDTO : IDTO<User>
   {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
        public void UpdateEntity(User user)
        {
            user.Id = new Guid().ToString();
            user.Email = Email;
        }
        public User ToEntity() => new User { Email = Email, };
   }
}
