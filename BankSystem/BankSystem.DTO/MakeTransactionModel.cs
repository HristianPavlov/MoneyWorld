using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using BankSystem.Models.Enums;

namespace BankSystem.DTO
{
    public class MakeTransactionModel : IMapFrom<Transaction>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int SenderBankAccountId { get; set; }

        public int ReceiverBankAccountId { get; set; }

        public decimal Amount { get; set; }

        public Currency Currency { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Transaction, MakeTransactionModel>()
                .ForMember(x => x.SenderBankAccountId, cfg
                    => cfg.MapFrom(x => x.SenderId))
                .ForMember(x => x.ReceiverBankAccountId, cfg
                    => cfg.MapFrom(x => x.ReceiverId))
                .ReverseMap();
        }
    }
}
