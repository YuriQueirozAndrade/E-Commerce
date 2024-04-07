#nullable enable
using E_Commerce_API.Application.Interfaces.DTOs;
using System.ComponentModel.DataAnnotations;
using E_Commerce_API.Core.Entities;
namespace E_Commerce_API.Application.DTOs
{
    public class LoginDTO : IDTO<User>
   {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public void UpdateEntity(User user)
        {
            user.Id = new Guid().ToString();
            user.Email = Email;
        }
        public User ToEntity()
        {
            return new User
            {
                Email = Email,
            };
        }
   }
}