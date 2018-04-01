using AutoMapper;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Services;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService cardService;

        public CardController(ICardService cardService)
        {
            this.cardService = cardService ?? throw new ArgumentNullException();
        }

        public static IEnumerable<BankAccountReadModel> BankAccounts { get; set; }

        [Authorize]
        public ActionResult AllCards()
        {
            string userName = this.User.Identity.Name;
            ClientModel clientModel = new ClientModel() { UserName = userName };
            IEnumerable<CardModel> allCardsOfUser = this.cardService.GetAllCardsOfUser(clientModel);
            return this.View(allCardsOfUser);
        }

        [Authorize]
        public ActionResult AddCard()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddCard(string number, string pin, DateTime expirationDate, string secretNumber, int idOfBankAccount)
        {
            string cardNumber = number;
            //DateTime expirationDate = expirationDate;
            int bankAccID = idOfBankAccount;

            CardModel cardToAdd = new CardModel()
            {
                Account = new BankAccountModel() { Id = idOfBankAccount },
                ExpirationDate = expirationDate,
                Number = number,
                Pin = pin,
                SecretNumber = secretNumber
            };

            cardService.AddCard(cardToAdd);
            this.PartialView("GetDropDownListOfBankAccountIDs");
            return View();
        }

        [Authorize]
        public ActionResult RemoveCard()
        {
            return this.View();
        }
    }
}