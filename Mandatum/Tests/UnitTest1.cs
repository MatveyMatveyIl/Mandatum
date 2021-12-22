using System;
using System.Collections.Generic;
using Application;
using Application.ApiInterface;
using Mandatum;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var serviceCollection = new ServiceCollection();
            IEnumerable<KeyValuePair<string, string>> confValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("TransactionLogging:Enabled", "True"),
                new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", "Data Source=mandatumdasha.database.windows.net;Initial Catalog=Mandatum;Persist Security Info= True; User Id=dasha;Password=Mandatum2038")
            };

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(confValues);
            var confRoot = builder.Build();
            
            var startUp = new Startup(confRoot);
            startUp.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var boardApi = serviceProvider.GetRequiredService<IBoardApi>();
            boardApi.AddTaskToBoard(new Guid("1178DA4F-242B-4038-B2B8-E0728BDE3BFE"), new TaskRecord());
        }
    }
}