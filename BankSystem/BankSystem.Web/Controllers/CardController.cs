using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
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

        [Authorize]
        public ActionResult AllCards()
        {
            string userName = this.User.Identity.Name;
            ClientModel clientModel = new ClientModel() { UserName = userName };
            IEnumerable<CardModel> allCardsOfUser = this.cardService.GetAllCardsOfUser(clientModel);
            return this.View(allCardsOfUser);
        }
    }
}