using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore.InMemory;
using Exchange.Infrastructure;
using Exchange.Infrastructure.EntityFrameworkDataAccess;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace test
{
    public class TestCurrencyRepository
    {   
        [Fact]
        public async void  CurrencyRepository_Get_Valid_Currency_Name()
        {

            //Create inMemory database
            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "InmemoryTestDataBase")
               .Options;

            //Create mocked context
            using (var context = new Context(options))
            {
                context.Currencies.Add(new Exchange.Infrastructure.EntityFrameworkDataAccess.Entities.Currency
                {
                    Id = 1,
                    Name = "dolar",
                    Url = "https://www.bancoprovincia.com.ar/",
                    MaxLimit = 200
                });

                context.Currencies.Add(new Exchange.Infrastructure.EntityFrameworkDataAccess.Entities.Currency
                {
                    Id = 2,
                    Name = "real",
                    Url = "https://www.bancoprovincia.com.ar/",
                    MaxLimit = 300
                });
                context.SaveChanges();
            }

            // use a context instance with data to test code

            using (var context = new Context(options))
            {
                CurrencyRepository currencyRepository = new CurrencyRepository(context);
                var currency = await currencyRepository.Get("dolar");

                Assert.Equal("https://www.bancoprovincia.com.ar/", currency.Url);
                Assert.Equal(200, currency.MaxLimit);
                Assert.IsType<Exchange.Domain.Quotes.Currency>(currency);
            }
        }

        [Fact]
        public async void CurrencyRepository_Get_Invalid_Currency_Name()
        {

            //Create inMemory database
            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "InmemoryTestDataBase")
               .Options;


            // use a context instance with data to test code

            using (var context = new Context(options))
            {
                CurrencyRepository currencyRepository = new CurrencyRepository(context);
                //var currency =  await currencyRepository.Get("badcurrency");

                await Assert.ThrowsAsync<CurrencyNotFoundException>(() => currencyRepository.Get("badcurrency"));
            }
        }
    }
}
