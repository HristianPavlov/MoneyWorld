using Autofac;
using AutoMapper;
using BankSystem.Common;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using BankSystem.Models.Enums;
using BankSystem.Services;
using System;
using System.Linq;
using System.Reflection;

namespace BankSystem.ConsoleClient
{
    class StartUp
    {
        static void Main()
        {
            Init();

            var transactionModel = new TransactionAddModel()
            {
                SenderId = 2,
                ReceiverId = 3,
                Amount = 10m,
                Currency = Currency.BGN,
                Date = DateTime.Now
            };

            var transactionToAdd = Mapper.Map<Transaction>(transactionModel);

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            var transactionService = new TransactionService();

            //transactionService.AddTransaction(transactionModel);

            var client = new ClientModel()
            {
                UserName = "aaaaaaaa"
            };

            //var result = transactionService.GetClientTransactionsFromDateToDate(client, new DateTime(2018, 03, 20), new DateTime(2018, 03, 22)).ToList();

            Console.WriteLine();



            //  transactionService.AddTransaction(transactionModel);
            ////controller.CreatePost("Added new post", DateTime.Now);


            ////var read = Console.ReadLine().Split(' ').ToList();

            ////controller.AddClient(read[0], read[1], read[2], read[3]);


            //var clients = controller.GetAll();
            ////var newww = new ClientModel();
            //foreach (var item in clients)
            //{
            //    Console.WriteLine(item.UserName);
            //}
        }

        private static void Init()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
