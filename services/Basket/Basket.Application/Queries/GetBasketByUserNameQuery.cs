using Basket.Application.Responses;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Basket.Application.Queries
{
    public class GetBasketByUserNameQuery :IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }
        public GetBasketByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
