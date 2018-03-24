using AutoMapper;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.Models;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public void AddCard(CardModel card)
        {
            ValidateCardObject(card);

            var cardToAdd = this.mapper.Map<Card>(card);

            this.dbContext.Cards.Add(cardToAdd);
            this.dbContext.SaveChanges();
        }

        public void DeleteCard(CardModel card)
        {
            ValidateCardObject(card);

            var cardToDelete = this.dbContext.Cards
                .First(x => x.Id == card.Id);

            cardToDelete.IsDeleted = true; //something should happen with the bank acount?


        }

        public CardModel GetCardById(int id)
        {
            bool exists = this.dbContext.Cards.Any(x => x.Id == id);

            if (!exists)
            {
                throw new Exception("");
            }

            var card = this.dbContext.Cards.First(x => x.Id == id);
            var cardToReturn = this.mapper.Map<CardModel>(card);
            
            return cardToReturn;
        }

        public ClientModel Owner(CardModel card)
        {
            //FAAAACK
            //var client = this.dbContext.Cards.Where(x => x.)
            throw new NotImplementedException();
        }

        public void UpdateCardInfo(int cardId, string pin, DateTime expirationTime)
        {
            if (CheckIfCardExistInDatabase(cardId))
            {
                var cardToUpdate = this.dbContext.Cards.First(x => x.Id == cardId);

                cardToUpdate.Pin = pin;
                cardToUpdate.ExpirationDate = expirationTime;

                this.dbContext.SaveChanges();
            }
            else
            {
                throw new Exception(string.Format("Card with id {0} does not exist in the databse", cardId));
            }
        }

        private void ValidateCardObject(CardModel card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("");
            }

            bool isValidBankAcount = this.dbContext.BankAccounts
                .Any(x => x.Id == card.Id);

            if (!isValidBankAcount)
            {
                throw new Exception("The bank acount you trying to asign card to does not exist.");
            }
        }

        private bool CheckIfCardExistInDatabase(int id)
        {
            bool ifExists = this.dbContext.Cards.Any(x => x.Id == id);

            return ifExists;
        }
    }
}
