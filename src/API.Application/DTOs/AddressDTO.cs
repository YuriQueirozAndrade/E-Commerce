#nullable enable
using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.DTOs
{
    public class AddressDTO : IDTO<Address>,IResponseDTO<Address>,IUserProperties
   {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }

        public void UpdateEntity(Address address)
        {
            address.City = City;
            address.State = State;
            address.ZipCode = ZipCode;
            address.Country = Country;
            address.UserId = UserId;
        }
        public Address ToEntity()
        {
            return new Address
            {
               City = City,
               State = State,
               ZipCode = ZipCode,
               Country = Country,
               UserId = UserId
            };
        }
        public IDTO<Address> ToDto(Address entity)
        {
          return new AddressDTO
          {
               City = entity.City,
               State = entity.State,
               ZipCode = entity.ZipCode,
               Country = entity.Country,
               UserId = entity.UserId
          };
        }
        public List<IDTO<Address>> ToDtoList(List<Address> entities)
        {
            List<IDTO<Address>> ad = new List<IDTO<Address>>(entities.Count);
            for (int i = 0; i < entities.Count; i++)
            {
                ad.Add(
                ToDto(entities[i])
                );
            }
            return ad;
        }
   }
}