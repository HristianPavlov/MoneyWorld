using BankSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
    public interface ICardService
    {
        void AddCard(CardModel card);

        void DeleteCard(CardModel card);

        void UpdateCardInfo(int cardId, string pin, DateTime expirationTime);

        ClientModel Owner(CardModel card);

        //get bankAcount

        CardModel GetCardById(int id);
    }
}
