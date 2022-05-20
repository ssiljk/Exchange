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
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                string[] bankApiQuoteResp = await JsonSerializer.DeserializeAsync<string[]>(responseStream);
                quote.SaleValue = Convert.ToDecimal(bankApiQuoteResp[1]);
                
            }
            return quote;
        }
    }
}
