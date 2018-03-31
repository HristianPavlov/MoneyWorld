using BankSystem.DTO;
using BankSystem.Services.Contracts;
using System;
using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IClientServices userService;

        public UserController(IClientServices userServices)
        {
            this.userService = userServices ?? throw new ArgumentNullException(nameof(userServices));
        }


        public ActionResult Index()
        {
            var userName = this.User.Identity.Name;

            var model = this.userService.GetAccountInfo(userName);

            return this.View(model);
        }

        public ActionResult ChangeName()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ChangeName(ChangeNameViewModel model)
        {
            model.UserName = this.User.Identity.Name;

            this.userService.ChangeUserNames(model);

            return this.RedirectToAction("Index", "User");
        }
    }
}