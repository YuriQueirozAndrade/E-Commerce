using Back_End.Interfaces;
namespace Back_End.Models.DTOs
{
   public class AddressDTO : IDTO<Address>
   {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public void UpdateEntity(Address address)
        {
            address.City = City;
            address.State = State;
            address.ZipCode = ZipCode;
            address.Country = Country;
        }
        public Address ToEntity()
        {
            return new Address
            {
               City = City,
               State = State,
               ZipCode = ZipCode,
               Country = Country
            };
        }
   }
}