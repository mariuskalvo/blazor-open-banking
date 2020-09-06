using BlazorBank.Infrastructure.Models.Cards;
using BlazorBank.Services.Mappers;
using BlazorBank.Services.Models;
using NUnit.Framework;
using System;

namespace BlazorBank.Services.Tests.Unit
{
    public class Tests
    {
        private ICardMapper _cardMapper;

        public Tests()
        {
            _cardMapper = new CardMapper();
        }

        [Test]
        public void MapCardExternalToCardInternal_IsMappedCorrectly()
        {
            var cardExternal = new CardExternal
            {
                AccountNumber = "ACCOUNT_NUMBER",
                AccountOwner = "ACCOUNT_OWNER",
                CardId = "CARD_ID",
                CardNumber = "CARD_NUMBER",
                CardType = "VISA",
                CardVersionNumber = 1,
                CustomerId = "00000000000",
                ExpiryDate = new DateTime(),
                ProductCode = "CreditCardCL",
                Status = "Active"
            };

            var actual = _cardMapper.MapCardExternalToCardInternal(cardExternal);

            Assert.AreEqual(actual.Status, CardStatus.Active);
            Assert.AreEqual(actual.AccountNumber, cardExternal.AccountNumber);
            Assert.AreEqual(actual.CardType, cardExternal.CardType);
            Assert.AreEqual(actual.ExpiryDate, cardExternal.ExpiryDate);
        }

        [Test]
        [TestCase("Active", CardStatus.Active)]
        [TestCase("Unknown", CardStatus.Unknown)]
        [TestCase("Inactive", CardStatus.Inactive)]
        [TestCase("Renewal", CardStatus.Renewal)]
        [TestCase("Deleted", CardStatus.Deleted)]
        [TestCase("Blocked", CardStatus.Blocked)]
        [TestCase("SomeUnknownText", CardStatus.Unknown)]
        public void MapCardExternalToCardInternal_CardStatusIsMappedCorrectly(string externalCardStatus, CardStatus internalCardStatus)
        {
            var cardExternal = new CardExternal
            {
                Status = externalCardStatus
            };

            var actual = _cardMapper.MapCardExternalToCardInternal(cardExternal);

            Assert.AreEqual(actual.Status, internalCardStatus);
        }
    }
}