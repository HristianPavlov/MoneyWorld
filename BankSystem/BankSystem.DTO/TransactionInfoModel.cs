using AutoMapper;
using BankSystem.Common.Mapping;
using BankSystem.Models;
using BankSystem.Models.Enums;
using System;

namespace BankSystem.DTO
{
    public class TransactionInfoModel : IMapFrom<Transaction>, IHaveCustomMappings
    {
        public int SenderId { get; set; }

        public string SenderAccountOwner { get; set; }

        public int ReceiverId { get; set; }

        public string ReveiverAccountOwner { get; set; }

        public decimal Amount { get; set; }

        public Currency Currency { get; set; }

        public DateTime Date { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //configuration.CreateMap<Transaction, TransactionInfoModel>()
            //    .ForMember(x => x.SenderAccountOwner, cfg
            //        => cfg.MapFrom(x => x.Sender.Owner.UserName + " / " +
            //                            x.Sender.Owner.FirstName + " " + x.Sender.Owner.LastName))
            //    .ForMember(x => x.ReveiverAccountOwner, cfg
            //        => cfg.MapFrom(x => x.Receiver.Owner.UserName + " / " +
            //                            x.Receiver.Owner.FirstName + " " + x.Receiver.Owner.LastName))
            //    .ReverseMap();
        }
    }
}
