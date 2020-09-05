using System.Globalization;

namespace BlazorBank.BlazorApp.Formatters
{
    public static class AccountFormatter
    {
        public static string FormatCurrentSum(double sum)
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";
            return sum.ToString("N2", nfi);
        }

        public static string FormatAccountNumber(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return "";

            if (accountNumber.Length != 11)
                return accountNumber;

            return $"{accountNumber.Substring(0, 4)}.{accountNumber.Substring(4, 2)}.{accountNumber.Substring(6)}";
        }
    }
}
