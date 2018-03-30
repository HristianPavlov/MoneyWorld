using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using System;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    public interface ICardService
    {
        IEnumerable<CardModel> GetAllCardsOfUser(ClientModel client);

        void AddCard(CardModel card);

        void DeleteCard(CardModel card);

        void DeleteCard(int id);

        void UpdateCardInfo(int cardId, string pin, DateTime expirationTime);

        ClientModel Owner(CardModel card);

        //get bankAcount

        CardModel GetCardById(int id);
    }
}
