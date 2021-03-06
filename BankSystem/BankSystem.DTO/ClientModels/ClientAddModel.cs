﻿using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO.ClientModels
{
    public class ClientAddModel : IMapFrom<ApplicationUser>
    {
        //public string FullName { get; set; }

        //public ClientAddModel()
        //{
        //    this.BankAccounts = new List<BankAccount>();
        //    this.Contacts = new List<ClientContact>();
            
        //}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        //public bool IsDeleted { get; set; }

        //public  ICollection<BankAccount> BankAccounts { get; set; }

        //public  ICollection<ClientContact> Contacts { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Client, ClientModel>()
        //        .ForMember(x => x.FullName, cfg
        //        => cfg.MapFrom(x => x.FirstName + " " + x.LastName));
        //}

    }
}
