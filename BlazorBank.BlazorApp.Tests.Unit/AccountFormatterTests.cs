using BlazorBank.BlazorApp.Formatters;
using NUnit.Framework;

namespace BlazorBank.BlazorApp.Tests.Unit
{
    public class Tests
    {
        [Test]
        public void FormatAccountNumber_AccountNumberIsNull_EmptyStringIsReturned()
        {
            var actual = AccountFormatter.FormatAccountNumber(null);
            Assert.AreEqual("", actual);
        }

        [Test]
        public void FormatAccountNumber_AccountNumberIsEmpty_EmptyStringIsReturned()
        {
            var actual = AccountFormatter.FormatAccountNumber("");
            Assert.AreEqual("", actual);
        }

        [Test]
        public void FormatAccountNumber_AccountNumberIsNot11Characters_AccountNumberIsReturnedUnformatted()
        {
            var expected = "123456789";
            var actual = AccountFormatter.FormatAccountNumber(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FormatAccountNumber_AccountNumberIsValid_AccountNumberIsCorrectlyFormatted()
        {
            var input = "11112233333";
            var expected = "1111.22.33333";
            var actual = AccountFormatter.FormatAccountNumber(input);
            Assert.AreEqual(expected, actual);
        }

    }
}