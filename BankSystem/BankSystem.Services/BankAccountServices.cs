using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.Models;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services
{
  public  class BankAccountServices: IBankAccountServices
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

            if (bankAccount==null)
            {
                throw new ArgumentNullException("the bankAccount you wish to add to the database is null, fix it now or cry latter");

            }
            var bankAccAdd= this.mapper.Map<BankAccount>(bankAccount);

            this.dbContext.BankAccounts.Add(bankAccAdd);
            this.dbContext.SaveChanges();

        }



        public BankAccountReadModel DeleteBankAccount(string id)

        {
            int ID = int.Parse(id);
            
            var bankacc= this.dbContext.BankAccounts.Where(x => x.Id == ID).FirstOrDefault();

            bankacc.IsDeleted = true;
            this.dbContext.SaveChanges();

                      
            return this.mapper.Map<BankAccountReadModel>(bankacc);
        }

        public IEnumerable <BankAccountReadModel> GetAllBankAccounts()
        {

            return this.dbContext.BankAccounts.ProjectTo<BankAccountReadModel>();
        }

        public BankAccountReadModel GetBankAccountByID(string id)
        {
            var bank = this.dbContext.BankAccounts.ProjectTo<BankAccountReadModel>().Where(x => x.Id == int.Parse(id)).FirstOrDefault();

            return bank;
        }





    }
}
