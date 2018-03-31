using AutoMapper;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Services
{
    public class CardService : ICardService
    {
        private readonly IBankSystemContext dbContext;
        private readonly IMapper mapper;

        public CardService(IBankSystemContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<CardModel> GetAllCardsOfUser(ClientModel client)
        {
            ApplicationUser user = this.dbContext.Users
                .ToList()
                .FirstOrDefault(x => x.UserName == client.UserName);

            IEnumerable<BankAccount> bankAcounts = this.dbContext.BankAccounts
                .ToList()
                .TakeWhile(x => x.Owner.Id == user.Id);

            IEnumerable<CardModel> allCards = bankAcounts
                .TakeWhile(x => x.Cards.Count != 0)
                .SelectMany(x => x.Cards)
                .Select(x => this.mapper.Map<CardModel>(x));

            return allCards;
        }

        public void AddCard(CardModel card)
        {
            CheckIfCardIsNull(card);
            CheckIfBankAcountExists(card);

            Card cardToAdd = this.mapper.Map<Card>(card);

            this.dbContext.Cards.Add(cardToAdd);
            this.dbContext.SaveChanges();
        }

        public void DeleteCard(CardModel card)
        {
            CheckIfCardIsNull(card);

            Card cardToDelete = this.dbContext.Cards
                .First(x => x.Id == card.Id);

            cardToDelete.IsDeleted = true;

            this.dbContext.SaveChanges();
        }

        public void DeleteCard(int id)
        {
            Card cardToDelete = this.dbContext.Cards
                .FirstOrDefault(x => x.Id == id);

            cardToDelete.IsDeleted = true;

            this.dbContext.SaveChanges();
        }

        public CardModel GetCardById(int CardId)
        {
            CheckIfCardExistInDatabase(CardId);

            Card card = this.dbContext.Cards
                .First(x => x.Id == CardId);

            CardModel cardToReturn = this.mapper.Map<CardModel>(card);

            return cardToReturn;
        }

        public ClientModel Owner(CardModel card)
        {
            ApplicationUser client = this.dbContext.Cards
                .Select(x => x.Account)
                .Select(x => x.Owner)
                .FirstOrDefault();

            ClientModel clientModel = this.mapper.Map<ClientModel>(client);

            return clientModel;
        }

        public void UpdateCardInfo(int cardId, string pin, DateTime expirationTime)
        {
            CheckIfCardExistInDatabase(cardId);

            Card cardToUpdate = this.dbContext.Cards.First(x => x.Id == cardId);

            cardToUpdate.Pin = pin;
            cardToUpdate.ExpirationDate = expirationTime;

            this.dbContext.SaveChanges();
        }

        private void CheckIfCardIsNull(CardModel card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("");
            }
        }

        private void CheckIfBankAcountExists(CardModel card)
        {
            bool isValidBankAcount = this.dbContext.BankAccounts
                .Any(x => x.Id == card.Id);

            if (!isValidBankAcount)
            {
                throw new Exception("The bank acount you trying to asign card to does not exist.");
            }
        }

        private void CheckIfCardExistInDatabase(int cardId)
        {
            bool ifExists = this.dbContext.Cards.Any(x => x.Id == cardId);

            if (!ifExists)
            {
                throw new Exception(string.Format("Card with id {0} does not exist in the databse", cardId));
            }
        }
    }
}
