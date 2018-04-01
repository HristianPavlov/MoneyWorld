using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.Models;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Services
{
    public class BankAccountServices : IBankAccountServices
    {

        private readonly IBankSystemContext dbContext;
        private readonly IMapper mapper;

        public BankAccountServices(IBankSystemContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddBankAccount(BankAccountAddAspModel bankAccount)
        {

            if (bankAccount == null)
            {
                throw new ArgumentNullException("the bankAccount you wish to add to the database is null, fix it now or cry latter");

            }
            var bankAccAdd = this.mapper.Map<BankAccount>(bankAccount);

            this.dbContext.BankAccounts.Add(bankAccAdd);
            this.dbContext.SaveChanges();

        }



        public BankAccountReadModel DeleteBankAccount(string id)

        {
            int ID = int.Parse(id);

            var bankacc = this.dbContext.BankAccounts.Where(x => x.Id == ID).FirstOrDefault();

            bankacc.IsDeleted = true;
            this.dbContext.SaveChanges();


            return this.mapper.Map<BankAccountReadModel>(bankacc);
        }

<<<<<<< HEAD

        public IEnumerable <BankAccountReadModel> GetAllBankAccounts()
=======
        public IEnumerable<BankAccountReadModel> GetAllBankAccounts()
>>>>>>> 866509dcff51a29876af5c7ca5d1a641563ad75a
        {

            return this.dbContext.BankAccounts.ProjectTo<BankAccountReadModel>();
        }



        public BankAccountReadModel GetBankAccountByID(string id)
        {

            var asd = int.Parse(id);
            var bank = this.dbContext.BankAccounts.Where(x => x.Id == asd).FirstOrDefault();

            var bankReadModel = this.mapper.Map<BankAccountReadModel>(bank);

            return bankReadModel;
        }

        public UserBankAccounts GetUserBankAccounts(string userName)
        {
            var bankAcc = this.dbContext.Users.FirstOrDefault(x => x.UserName == userName);

            var userBankAcc = this.mapper.Map<UserBankAccounts>(bankAcc);

            return userBankAcc;
        }
    }
}
