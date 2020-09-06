using BlazorBank.Infrastructure.Models.Cards;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public interface ICardProxy
    {
        Task<GetCardsResponse> GetCards(string customerId);
    }
}
