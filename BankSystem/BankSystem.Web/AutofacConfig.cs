using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using BankSystem.Data;
using BankSystem.Data.Contracts;
using BankSystem.Services;
using BankSystem.Services.Contracts;
using System.Web.Mvc;

namespace BankSystem.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterType<BankSystemContext>().As<IBankSystemContext>().InstancePerDependency();

            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerDependency();

            builder.RegisterType<BankAccountServices>().As<IBankAccountServices>().InstancePerDependency();

            builder.Register(x => Mapper.Instance);


            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
<<<<<<< HEAD

    public interface ITest
    {
        string Str { get; set; }
    }

    public class Test : ITest
    {
        public string Str { get; set; }
    }
=======
>>>>>>> 98b5885efde2b78c6dae36e2555d0e8f5125df93
}