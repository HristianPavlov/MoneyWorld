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
    public class CardModel : IMapFrom<Card>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Number { get; set; }
        
        public string Pin { get; set; }
        
        public DateTime? ExpirationDate { get; set; }
        
        public string SecretNumber { get; set; }
        
        public virtual BankAccount Account { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Card, CardModel>();
        }
    }
}
