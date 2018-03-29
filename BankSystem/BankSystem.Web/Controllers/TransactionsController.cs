using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        // /Transation/AllTransactions?pesho="sadasds"&gosho="asda"&age=14

        [Authorize]
        public ActionResult Index()
        {
            var userName = this.User.Identity.Name;

            var transactionViewModel = new ClientModel()
            { UserName = userName };

            var allTrransactions = this.transactionService.GetTransactions(transactionViewModel);

            return this.View(allTrransactions);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var userName = this.User.Identity.Name;

            var transactionViewModel = new TransactionViewModel()
            {
                UserName = userName,
                StartDate = startDate,
                EndDate = endDate
            };

            var allTrransactions = this.transactionService.GetClientTransactionsFromDateToDate(transactionViewModel);

            return this.View(allTrransactions);
        }
    }
}