using BlazorBank.Infrastructure.Models.Cards;
using BlazorBank.Services.Models;

namespace BlazorBank.Services.Mappers
{
    public interface ICardMapper
    {
        CardInternal MapCardExternalToCardInternal(CardExternal card);
    }
}
