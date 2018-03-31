using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using System.Linq;

namespace BankSystem.DTO
{
    public class AccountViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Amount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, AccountViewModel>()
                .ForMember(x => x.Amount, cfg => cfg.MapFrom(x => x.BankAccounts.Sum(y => y.Amount)));
        }
    }
}
