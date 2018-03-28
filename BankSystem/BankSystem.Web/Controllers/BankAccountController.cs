using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: BankAccount
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly IBankAccountServices bankAccountService;

        public BankAccountController(IBankAccountServices bankAccountService)
        {
             this.bankAccountService = bankAccountService ?? throw new ArgumentNullException(nameof(bankAccountService));
        }


        [Authorize]
        public ActionResult BankAccountGetAll()
        {
            //var userName = this.User.Identity.Name;

           // var clientModel = new ClientModel() { UserName = userName };

            var Allacc = this.bankAccountService.GetAllBankAccounts();


            return this.View(Allacc);
        }
    }
}