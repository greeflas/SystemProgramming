using System;
using System.Collections.Generic;

namespace Privat24API
{
    public class ExchangeRate
    {
        public string baseCurrency { get; set; }
        public string currency { get; set; }
        public decimal saleRateNB { get; set; }
        public decimal purchaseRateNB { get; set; }
        public decimal saleRate { get; set; }
        public decimal purchaseRate { get; set; }
    }

    public class UserServices
    {
        public DateTime date { get; set; }
        public string bank { get; set; }
        public int baseCurrency { get; set; }
        public string baseCurrencyLit { get; set; }

        public List<ExchangeRate> exchangeRate { get; set; }
    }
}
