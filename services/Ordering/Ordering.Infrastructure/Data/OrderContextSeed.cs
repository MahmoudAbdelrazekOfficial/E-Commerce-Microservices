using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database :{typeof(OrderContext).Name} seeded");
            }
        }
        public static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new()
                {
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    EmailAddress = "admin@meemdev.com",
                    AddressLine ="Alex",
                    Country = "Egypt",
                    TotalPrice = 1000,
                    State ="EG",
                    ZipCode = "12345",

                    CardName = "Visa",
                    CardNumber = "1234567890123456",
                    CreatedBy = "admin",
                    Expiration = "12/7",
                    Cvv = "123",
                    PaymentMethod = 1,
                    LastModifiedBy = "admin",
                    LastModifiedDate = new DateTime()

                }
            };
        }

    }
}
