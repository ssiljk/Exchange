using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Exchange.Domain.Quotes;
using Exchange.Application.Queries;
using Exchange.Application.ExternalApis;
using System.Text.Json;
using System.Globalization;

namespace Exchange.Infrastructure.ExternalApis
{
    public class BankApi : IBankApi
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICurrencyQuery _currencyQuery;

        public BankApi(IConfiguration configuration,
                       IHttpClientFactory httpClientFactory,
                       ICurrencyQuery currencyQuery
                      )
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _currencyQuery = currencyQuery;
        }

        public async Task<Quote> Get(string currencyName)
        {
            var currencyResult = await _currencyQuery.GetCurrency(currencyName);
            var client = _httpClientFactory.CreateClient();
            string url = currencyResult.QuoteUrl;
            string route = "Principal/";
            string query = currencyResult.CurrencyName;
            string requestString = $"{url}{route}{query}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestString);
            request.Headers.Add("Accept", "application/json");
            var response = client.SendAsync(request).Result;
            Quote quote = new Quote();
            quote.CurrencyName = currencyResult.CurrencyName;
            quote.DateTime = DateTime.Now;
            quote.TransactionLimit = currencyResult.TransactionLimit;
            if (response.IsSuccessStatusCode)
            {
                CultureInfo formatProvider;
                formatProvider = new CultureInfo("en-EN");
                //formatProvider = new CultureInfo("fr-FR");
                using var responseStream = await response.Content.ReadAsStreamAsync();
                string[] bankApiQuoteResp = await JsonSerializer.DeserializeAsync<string[]>(responseStream);
                try
                {
                    quote.SaleValue = Convert.ToDecimal(bankApiQuoteResp[1], formatProvider);
                }
                catch (System.OverflowException)
                {
                    System.Console.WriteLine(
                        "The conversion from string to decimal overflowed.");
                }
                catch (System.FormatException)
                {
                    System.Console.WriteLine(
                        "The string is not formatted as a decimal.");
                }
                catch (System.ArgumentNullException)
                {
                    System.Console.WriteLine(
                        "The string is null.");
                }


            }
            return quote;
        }
    }
}
