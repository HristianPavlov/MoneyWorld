using BankSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
  public  interface IClientServices
    {
        void AddClient(ClientModel client);

        IQueryable<ClientModel> GetClients();

    }
}
