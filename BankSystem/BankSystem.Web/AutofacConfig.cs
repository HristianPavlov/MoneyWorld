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

            builder.RegisterType<ClientServices>().As<IClientServices>().InstancePerDependency();

            builder.RegisterType<BankAccountServices>().As<IBankAccountServices>().InstancePerDependency();

            builder.RegisterType<CardService>().As<ICardService>().InstancePerDependency();

            builder.RegisterType<ExchangeRateService>().As<IExchangeRateService>().InstancePerDependency();

            builder.Register(x => Mapper.Instance);


            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}