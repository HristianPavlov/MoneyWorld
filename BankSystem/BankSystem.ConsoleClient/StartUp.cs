using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using BankSystem.Common;
using BankSystem.ConsoleClient.Controllers;
using BankSystem.Data;
using BankSystem.DTO;
using BankSystem.Models;

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

            var controller = container.Resolve<ClientController>();

            //controller.CreatePost("Added new post", DateTime.Now);


            //var read = Console.ReadLine().Split(' ').ToList();

            //controller.AddClient(read[0], read[1], read[2], read[3]);


            var clients = controller.GetAll();
            //var newww = new ClientModel();
            foreach (var item in clients)
            {
                Console.WriteLine(item.UserName);
            }
        }

        private static void Init()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
