using Autofac;
using AutoMapper;
using BankSystem.ConsoleClient.Controllers;
using BankSystem.Data;
using BankSystem.Data.Contracts;
using BankSystem.Services;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.ConsoleClient.AutofacModules
{
  public  class AutofacModule:Module

    {
        protected override void Load( ContainerBuilder builder)
        {
            builder.RegisterType<BankSystemContext>().As<IBankSystemContext>().InstancePerDependency();

            builder.RegisterType<ClientServices>().As<IClientServices>().InstancePerDependency();

            builder.RegisterType<ClientController>().AsSelf().InstancePerDependency();

            builder.RegisterType<CardService>().As<ICardService>().InstancePerDependency();

            builder.Register(x => Mapper.Instance);

        }

    }
}
