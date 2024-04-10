#nullable enable
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Core.Entities
{
    public class Address : Base,IUserProperties
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
