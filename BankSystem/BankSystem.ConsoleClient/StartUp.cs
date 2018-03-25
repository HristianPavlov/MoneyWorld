using Autofac;
using AutoMapper;
using BankSystem.Common;
using BankSystem.ConsoleClient.Controllers;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using BankSystem.Models.Enums;
using BankSystem.Services;
using BankSystem.Services.Contracts;
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

            var builder = new ContainerBuilder(); 
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            //var clientAddModel = new ClientAddModel()
            //{
            //    FirstName = "NaMaika",
            //    LastName = "Znaesh",
            //    UserName = "Drunkkkkkkkk",
            //    Password = "123456"
                
            //};

            //var controller = new ClientController();

            var controller = container.Resolve<ClientController>();
            var clientService = container.Resolve<IClientServices>();

            //var client = clientService.GetClientByID(1);

            var clients = clientService.GetClients();
            foreach (var item in clients)
            {
                foreach (var ss in item.BankAccountsID)
                {
                    Console.WriteLine(ss.Id);
                }
                Console.WriteLine(item.UserName);

            }


            // clientService.AddClient(clientAddModel);

            //var transactionModel = new TransactionAddModel()
            //{
            //    SenderId = 5,
            //    ReceiverId = 9,
            //    Amount = 10m,
            //    Currency = Currency.BGN,
            //    Date = DateTime.Now
            //};

            //var transactionToAdd = Mapper.Map<Transaction>(transactionModel);



            var transactionService = new TransactionService();

            //transactionService.AddTransaction(transactionModel);

            //var client = new ClientModel()
            //{
            //    UserName = "aaaaaaaa"
            //};

            var bank = new BankAccountModel()
            {
                Id = 5
            };
            var result = transactionService.GetBankAccountTransactionsFromDateToDate(bank, new DateTime(2018, 03, 20), new DateTime(2018, 03, 27)).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Amount);
            }
            



            //  transactionService.AddTransaction(transactionModel);
            //controller.CreatePost("Added new post", DateTime.Now);


            ////var read = Console.ReadLine().Split(' ').ToList();

            ////controller.AddClient(read[0], read[1], read[2], read[3]);


            //var clientss = controller.GetAll();
            ////var newww = new ClientModel();
            //foreach (var item in clientss)
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
