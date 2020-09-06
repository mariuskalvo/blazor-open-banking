using BlazorBank.Infrastructure.Models.Cards;
using BlazorBank.Services.Models;

namespace BlazorBank.Services.Mappers
{
    public class CardMapper : ICardMapper
    {
        public CardInternal MapCardExternalToCardInternal(CardExternal card)
        {
            return new CardInternal
            {
                AccountNumber = card.AccountNumber,
                CardType = card.CardType,
                ExpiryDate = card.ExpiryDate,
                Status = MapCardStatus(card.Status)
            };
        }

        private CardStatus MapCardStatus(string cardStatus)
        {
            switch (cardStatus)
            {

                case "Active":
                    return CardStatus.Active;
                case "Inactive":
                    return CardStatus.Inactive;
                case "Renewal":
                    return CardStatus.Renewal;
                case "Deleted":
                    return CardStatus.Deleted;
                case "Blocked":
                    return CardStatus.Blocked;
                case "Unknown":
                    return CardStatus.Unknown;
                default:
                    return CardStatus.Unknown;
            }
        }
    }
}
