#nullable enable
using Back_End.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Back_End.Models.DTOs
{
    public class LoginDTO : IDTO<User>
   {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public void UpdateEntity(User user)
        {
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