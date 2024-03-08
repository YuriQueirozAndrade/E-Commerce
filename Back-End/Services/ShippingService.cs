using Back_End.Interfaces;
using Back_End.Models;
namespace Back_End.Services
{
    public class ShippingService :IShippingService<Shipping> 
    {

        public Shipping CreateShipping()
        { 
            return new Shipping
            {
                Service = "TestDemoService",
                Cost = 100, 
                TrackingNumber = "TestTrackingNumber",
                ShippedDate = null
            };
        }
    }
}