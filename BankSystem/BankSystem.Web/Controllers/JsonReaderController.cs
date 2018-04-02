using BankSystem.Services;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    public class JsonReaderController : Controller
    {
        // GET: JsonReader

        private readonly IBankAccountServices bankAccountService;
        private readonly IJsonReader jreader;


        public JsonReaderController(IBankAccountServices bankAccountService, IJsonReader jreader)
        {
            this.bankAccountService = bankAccountService ?? throw new ArgumentNullException(nameof(bankAccountService));
            this.jreader = jreader ?? throw new ArgumentNullException(nameof(jreader));

        }

        [Authorize]
        public ActionResult JsonReader()
        {

            return View("WritingPath");
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult JsonReader(string path)
        {

            var bankList = this.jreader.BankAccountFromJson(path);

            foreach (var item in bankList)
            {
                bankAccountService.AddBankAccount(item);
            }

            return View();
        }
    }
}