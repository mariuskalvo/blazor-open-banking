using BlazorBank.Infrastructure.Models.AccessToken;
using BlazorBank.Infrastructure.Models.Cards;
using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Services.Mappers;
using BlazorBank.Services.Models;
using BlazorBank.Services.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBank.Services.Tests.Unit
{
    public class CardServiceTest
    {

        private ICardService _cardService;
        private Mock<ICardProxy> _cardProxyMock;
        private Mock<IAccessTokenProxy> _accessTokenProxyMock;
        
        public CardServiceTest()
        {
            _cardProxyMock = new Mock<ICardProxy>();
            _accessTokenProxyMock = new Mock<IAccessTokenProxy>();
            _accessTokenProxyMock.Setup(a => a.GetAccessToken(It.IsAny<string>())).ReturnsAsync(new GetAccessTokenResponse
            {
                AccessToken = "AccessToken",
                TokenType = "TokenType",
                ExpiresIn = 3600,
            });

            var cardMapper = new CardMapper();
            var customerConfiguration = new CustomerConfiguration { CustomerId = "CustomerId" };

            _cardService = new CardService(_cardProxyMock.Object, cardMapper, customerConfiguration);
        }

        [Test]
        public async Task GetCards_OnlyActiveCardsAreReturned()
        {
            _cardProxyMock.Setup(c => c.GetCards(It.IsAny<string>())).ReturnsAsync(new GetCardsResponse
            {
                AvailableItems = 2,
                Items = new List<CardExternal>
                {
                    new CardExternal { Status = "Active" },
                    new CardExternal { Status = "Deleted" },
                }
            });

            var cards = await _cardService.GetCards();

            Assert.IsTrue(cards.Count() == 1);
        }

    }
}
