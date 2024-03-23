#nullable enable
using Back_End.Interfaces;
namespace Back_End.Models.DTOs
{
    public class ProductDTO : IDTO<Product>,IResponseDTO<Product>
   {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void UpdateEntity(Product product)
        {
            product.Name = Name;
            product.Description = Description;
            product.Price = Price;
        }
        public Product ToEntity()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                Price = Price,
            };
        }
        public IDTO<Product> ToDto(Product prod)
        {
            return new ProductDTO
            {
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
            };
        }
        public List<IDTO<Product>> ToDtoList(List<Product> entities)
        {
            List<IDTO<Product>> ad = new List<IDTO<Product>>(entities.Count);
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