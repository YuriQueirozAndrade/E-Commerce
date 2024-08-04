using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Core.Entities
{
    public class Address : Base,IUserProperties
    {
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
