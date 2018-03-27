using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO.ClientModels
{
   public class ClientReadModel : IMapFrom<ApplicationUser>,IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BankAccountReadModel> BankAccountsID { get; set; }

       public  ICollection<ContactsReadModel> Contacts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ClientReadModel>()
                .ForMember(x => x.FullName, cfg
                => cfg.MapFrom(x => x.FirstName + " " + x.LastName))
                //.ForMember(x => x.BankAccountsID, cfg => cfg.MapFrom(x => x.BankAccounts.Select(t => t.Id)))
                //.ForMember(x => x.Contacts, cfg => cfg.MapFrom(x => x.Contacts.Select(t => t.Id)))
                .ReverseMap();
        }

    }
}
