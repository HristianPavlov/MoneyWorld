using BankSystem.Common.Mapping;
using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO.ClientModels
{
   public class ClientModel : IMapFrom<Client>

    {

        public string UserName { get; set; }
    }
}
