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
    public class TestTransactionRepository
    {
        [Fact]

        public async void TransactionRepository_Get_Valid_Transaction_Amount()
        {
            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "InmemoryTestDataBase")
               .Options;

            using (var context = new Context(options))
            {
                context.Transactions.Add(new Exchange.Infrastructure.EntityFrameworkDataAccess.Entities.Transaction
                {
                    Id = 1,
                    UserId = "user1",
                    Amount = 100,
                    CurrencyName = "dolar",
                    TransactionDate = DateTime.Now
                });

                context.Transactions.Add(new Exchange.Infrastructure.EntityFrameworkDataAccess.Entities.Transaction
                {
                    Id = 2,
                    UserId = "user1",
                    Amount = 60,
                    CurrencyName = "dolar",
                    TransactionDate = DateTime.Now
                });
                context.SaveChanges();
            }

            using (var context = new Context(options))
            {
                TransactionRepository transactionRepository = new TransactionRepository(context);

                var amount = await transactionRepository.GetTransactionsAmount("user1", "dolar");

                Assert.Equal(160, amount);
            }
        }

        [Fact]
        public async void TransactionRepository_Get_Transaction_Amount_of_0()
        {
            var options = new DbContextOptionsBuilder<Context>()
               .UseInMemoryDatabase(databaseName: "InmemoryTestDataBase")
               .Options;

            using (var context = new Context(options))
            {
                TransactionRepository transactionRepository = new TransactionRepository(context);

                var amount = await transactionRepository.GetTransactionsAmount("userx", "dolar");

                Assert.Equal(0, amount);
            }

        }

    }
}
