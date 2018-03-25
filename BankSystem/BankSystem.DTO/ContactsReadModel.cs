using BankSystem.Common.Mapping;
using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
   public class ContactsReadModel:   IMapFrom<ClientContact>
    {
        public int Id { get; set; }
    }
}
