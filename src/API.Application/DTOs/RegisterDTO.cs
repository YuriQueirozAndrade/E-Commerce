#nullable enable
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Application.DTOs
{
    public class RegisterDTO : IDTO<User>
   {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public void UpdateEntity(User user)
        {
            user.UserName = UserName;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
        }
        public User ToEntity()
        {
            return new User
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
            };
        }
   }
}
