using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    public interface IClientServices
    {
        // void AddClient(ClientAddModel client);

        IEnumerable<ClientReadModel> GetClients();

        ClientReadModel GetClientByID(string ID);

        ClientReadModel DeleteClientByID(string ID);

        AccountViewModel GetAccountInfo(string userName);

        void ChangeUserNames(ChangeNameViewModel model);
    }
}
