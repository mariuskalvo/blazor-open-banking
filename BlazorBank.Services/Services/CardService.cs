using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Services.Mappers;
using BlazorBank.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBank.Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardProxy _cardProxy;
        private readonly ICardMapper _cardMapper;
        private readonly CustomerConfiguration _customerConfiguration;

        public CardService(ICardProxy cardProxy, ICardMapper cardMapper, CustomerConfiguration customerConfiguration)
        {
            _cardProxy = cardProxy;
            _customerConfiguration = customerConfiguration;
            _cardMapper = cardMapper;
        }

        public async Task<IEnumerable<CardInternal>> GetCards()
        {
            var customerId = _customerConfiguration.CustomerId;
            var getCardsResponse = await _cardProxy.GetCards(customerId);

            if (getCardsResponse.Items == null)
                return new List<CardInternal>();

            return getCardsResponse.Items
                .Select(_cardMapper.MapCardExternalToCardInternal)
                .Where(c => c.Status == CardStatus.Active);
        }
    }
}
