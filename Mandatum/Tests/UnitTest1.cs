using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Api;
using Application.ApiInterface;
using Application.Entities;
using Mandatum;
using Mandatum.Controllers;
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
            boardApi.AddTaskToBoard(new Guid("1178DA4F-242B-4038-B2B8-E0728BDE3BFE"), new TaskRecord(), "hello");
        }
        
        [Test]
        public void Test2()
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
            boardApi.AddTaskToBoard(new Guid("1178DA4F-242B-4038-B2B8-E0728BDE3BFE"), new TaskRecord(), "111");
            boardApi.AddNewUserToBoard("222", new Guid("1178DA4F-242B-4038-B2B8-E0728BDE3BFE"));

        }
        
        [Test]
        public void Test3()
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
           
            var taskApi = serviceProvider.GetRequiredService<ITaskApi>(); 
            taskApi.DeleteTask(new Guid("1188DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            taskApi.SaveTask(new TaskRecord(){Id = new Guid("1188DA4F-252B-4038-B2B8-E0728BDE3BFE"), Name = "hello1"});
            var task = taskApi.GetTask(new Guid("1188DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            Assert.AreEqual(task.Name, "hello1");
           
        }
        
        [Test]
        public void Test4()
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
            var taskApi = serviceProvider.GetRequiredService<ITaskApi>(); 
            taskApi.DeleteTask(new Guid("1998DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            taskApi.SaveTask(new TaskRecord(){Id = new Guid("1998DA4F-252B-4038-B2B8-E0728BDE3BFE"), Name = "hello1"});
            var task = taskApi.GetTask(new Guid("1998DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            Assert.AreEqual(task.Id, new Guid("1998DA4F-252B-4038-B2B8-E0728BDE3BFE"));
        }
        [Test]
        public void Test5()
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
            boardApi.DeleteBoard(new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            boardApi.CreateBoard(new BoardRecord(){Id = new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"), Name = "12"}, "iulpv");
            var name = boardApi.GetBoardName(new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            Assert.AreEqual(name, "12");
        }
        [Test]
        public void Test6()
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
            boardApi.DeleteBoard(new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            boardApi.CreateBoard(new BoardRecord(){Id = new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"), Name = "12"}, "iulpv");
            boardApi.AddTaskToBoard(new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"), new TaskRecord(){Name = "1", Id = new Guid("2991DA4F-252B-4038-B2B8-E0728BDE3BFE")}, "iulp");
            var board = boardApi.GetBoard(new Guid("1991DA4F-252B-4038-B2B8-E0728BDE3BFE"));
            Assert.AreEqual(board.TaskIds.Count, 1);
        }
        
    }


}