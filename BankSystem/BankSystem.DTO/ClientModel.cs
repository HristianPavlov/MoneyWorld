using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
    public class ClientModel : IMapFrom<Client>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public int Id { get; set; }
             
        public string UserName { get; set; }
                     
        public  ICollection<BankAccount> BankAccounts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Client, ClientModel>()
                .ForMember(x => x.FullName, cfg
                => cfg.MapFrom(x => x.FirstName + " " + x.LastName));
        }

    }
}
