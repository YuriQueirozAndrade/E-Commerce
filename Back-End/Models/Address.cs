#nullable enable
using Back_End.Models.BaseModels;
namespace Back_End.Models
{
    public class Address : Base
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
