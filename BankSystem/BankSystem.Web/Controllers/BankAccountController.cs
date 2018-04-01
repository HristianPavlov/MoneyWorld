using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankSystem.DTO;

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

    

        [Authorize]
        public ActionResult BankAccountGetById()
        {
          // var banksAcc= this.bankAccountService.GetAllBankAccounts().FirstOrDefault();

            return View("WritingId");

        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult BankAccountGetById(string id)
        {

            var banksAcc = this.bankAccountService.GetBankAccountByID(id);



            return this.View(banksAcc);
        }

        /// <summary>
        /// Wait for Card Delete  and then add  updated this shit here ????
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult BankAccountDeleteById()
        {


            return View("WritingId");
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBankAccountByID(string id)
        {
            var bankacc = this.bankAccountService.DeleteBankAccount(id);


            //foreach (var card in bankacc.Cards)
            //{
            //    this.cardService.DeleteCard(card.Id);
            //}

            return this.View();
        }





        [Authorize]
        public ActionResult AddBankAccount()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddBankAccount(BankAccountAddAspModel model)
        {//[Bind(Include =            "BankAccountType,Amount,Currency,Owner,IsDeleted")]
            var user = new BankAccountAddAspModel { BankAccountType = model.BankAccountType, Amount = model.Amount, Currency = model.Currency, OwnerId = model.OwnerId, IsDeleted = model.IsDeleted };

            //if (ModelState.IsValid)
            //{
            // var user = new BankAccount { BankAccountType=model.BankAccountType,Amount=model.Amount,Currency=model.Currency,Owner=model.Owner,IsDeleted=model.IsDeleted };
            //UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName
            //var result = await UserManager.CreateAsync(user, model.Password);

            if (ModelState.IsValid)
            {


                bankAccountService.AddBankAccount(user);
                //db.PersonalDetails.Add(personalDetail);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //if (result.Succeeded)
            //    {
            //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            //        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
            //        // Send an email with this link
            //        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //        return RedirectToAction("Index", "Home");
            //    }



            //ModelState.AddModelError("Email", "Email not found or matched");
            //return View(model);

        }
    }
}