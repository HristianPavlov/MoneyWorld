using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IBankAccountServices bankAccountServices;

        public TransactionsController(ITransactionService transactionService, IBankAccountServices bankAccountServices)
        {
            this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            this.bankAccountServices = bankAccountServices;
        }

        // /Transation/AllTransactions?pesho="sadasds"&gosho="asda"&age=14

        public ActionResult Index()
        {
            var userName = this.User.Identity.Name;

            var transactionViewModel = new ClientModel()
            { UserName = userName };

            var allTrransactions = this.transactionService.GetTransactions(transactionViewModel);

            return this.View(allTrransactions);
        }

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

        public ActionResult MakeTransaction()
        {
            var userName = this.User.Identity.Name;

            var bankAccounts = this.bankAccountServices.GetUserBankAccounts(userName);

            var model = new MakeTransactionWithDropDownViewModel()
            {
                BankAccounts = bankAccounts,
                TransactionModel = new MakeTransactionModel()
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult MakeTransaction(MakeTransactionWithDropDownViewModel model)
        {
            var userName = this.User.Identity.Name;

            var makeTransactionModel = model.TransactionModel;

            makeTransactionModel.UserName = userName;

            this.transactionService.MakeTransaction(makeTransactionModel);

            return this.Redirect("Index");
        }
    }
}