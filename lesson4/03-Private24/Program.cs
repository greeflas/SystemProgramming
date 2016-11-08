using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Privat24API;

namespace _03_Private24
{
    class Program
    {
        public static void GetCurrency(object date)
        {
            DateTime d = (DateTime)date;
            while (d < DateTime.Now)
            {
                string url = "https://api.privatbank.ua/p24api/exchange_rates?json&date=" + d.ToShortDateString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                string answer = string.Empty;
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        answer = reader.ReadToEnd();
                    }
                }

                var servicedata = JsonConvert
                    .DeserializeObject<UserServices>(answer, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

                foreach (var item in servicedata.exchangeRate)
                {
                    if (item.currency == "USD")
                    {
                        string Date = d.ToShortDateString();
                        decimal USD = item.purchaseRate;

                        Console.WriteLine($"Date: {Date}");
                        Console.WriteLine($"USD: {USD:f}");
                        Console.WriteLine();
                    }
                }

                Thread.Sleep(1000);
                d = d.AddDays(1);
            }
        }

        static void Main(string[] args)
        {
            Task task = new Task(GetCurrency, new DateTime(2016, 10, 1));
            task.Start();
            task.Wait();
        }
    }
}
