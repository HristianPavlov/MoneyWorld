using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        [Authorize]
        public ActionResult AllTransactions()
        {
            var userName = this.User.Identity.Name;

            var clientModel = new ClientModel() { UserName = userName };

            var allTrransactions = this.transactionService.GetAllClientTransactions(clientModel);

            return this.View(allTrransactions);
        }
    }
}