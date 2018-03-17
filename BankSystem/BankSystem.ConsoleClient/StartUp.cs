using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using BankSystem.Common;
using BankSystem.Data;
using BankSystem.Models;

namespace BankSystem.ConsoleClient
{
    class StartUp
    {
        static void Main()
        {
            Init();

        }

        private static void Init()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
