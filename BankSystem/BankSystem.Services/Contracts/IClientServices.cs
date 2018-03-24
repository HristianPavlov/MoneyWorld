using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
  public  interface IClientServices
    {
        void AddClient(ClientAddModel client);

        IEnumerable<ClientReadModel> GetClients();

        ClientReadModel GetClientByID(int ID);

        ClientReadModel DeleteClientByID(int ID);



    }
}
