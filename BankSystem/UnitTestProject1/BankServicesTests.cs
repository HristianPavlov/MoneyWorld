using System;
using AutoMapper;
using BankSystem.Data;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BankSystem.Services;
using BankSystem.DTO;
using BankSystem.Models.Enums;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class BankServicesTests
    {
        [TestMethod]
        public void BankAccountAddService_should_Add_ToDataBase_When_ToldTo()
        {// Tva ne e na Sashko , ne e i na Sashka 
            //Arrange
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());
            var mapperMock = new Mock<IMapper>();
            var user = new ApplicationUser()
            {
                PasswordHash = "1234",
                PhoneNumber = "12455",
                FirstName = "asdfgh",
                LastName = "lastName",
                UserName = "abv@abv.bg",
                Email = "abv@abv.bg"

            };
            effortContext.Users.Add(user);

            var bank = new BankAccountAddAspModel()
            {
                // Id=1,
                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false

            };

            var bankMock = new BankAccount()
            {
                // Id = 1,
                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false
            };

            mapperMock.Setup(x => x.Map<BankAccount>(It.IsAny<BankAccountAddAspModel>()))
                      .Returns(bankMock);

            //Act
            var sut = new BankAccountServices(effortContext, mapperMock.Object);
            sut.AddBankAccount(bank);



            // Assert

            Assert.AreEqual(1, effortContext.BankAccounts.Count());

        }
        
        [TestMethod]
        public void BankAccount_Should_Delete_By_Id()
        {
            
            //Arrange
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());
            var mapperMock = new Mock<IMapper>();

            var user = new ApplicationUser()
            {
                PasswordHash = "1234",
                PhoneNumber = "12455",
                FirstName = "asdfgh",
                LastName = "lastName",
                UserName = "abv@abv.bg",
                Email = "abv@abv.bg"

            };
            effortContext.Users.Add(user);

            var bank = new BankAccountAddAspModel()
            {
                
                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false

            };

            var bankMock = new BankAccount()
            {
               
                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false
            };

            mapperMock.Setup(x => x.Map<BankAccount>(It.IsAny<BankAccountAddAspModel>()))
                      .Returns(bankMock);


            var sut = new BankAccountServices(effortContext, mapperMock.Object);
            sut.AddBankAccount(bank);
            //Act
            sut.DeleteBankAccount(bankMock.Id.ToString());

            Assert.IsTrue(effortContext.BankAccounts.Where(x => x.Id == bankMock.Id).FirstOrDefault().IsDeleted==true);
            
        }

       


        [TestMethod]
        public void BankAccount_Should_GetAccount_By_Id()
        {

            //Arrange
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());
            var mapperMock = new Mock<IMapper>();
          
            var user = new ApplicationUser()
            {
                PasswordHash = "1234",
                PhoneNumber = "12455",
                FirstName = "asdfgh",
                LastName = "lastName",
                UserName = "abv@abv.bg",
                Email = "abv@abv.bg"

            };
            effortContext.Users.Add(user);

            var bank = new BankAccountAddAspModel()
            {

                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false

            };

            var bankMock = new BankAccount()
            {

                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false
            };

            var bankReadModel = new BankAccountReadModel()
            {
                
                BankAccountType = (BankAccountType)1,
                Amount = 12345,
                Currency = (Currency)973,
                OwnerId = user.Id,
                IsDeleted = false

            };
            mapperMock.Setup(x => x.Map<BankAccount>(It.IsAny<BankAccountAddAspModel>()))
                      .Returns(bankMock);

            mapperMock.Setup(x => x.Map<BankAccountReadModel>(It.IsAny<BankAccount>()))
                      .Returns(bankReadModel);

            var sut = new BankAccountServices(effortContext, mapperMock.Object);
            sut.AddBankAccount(bank);
            //Act
           var result= sut.GetBankAccountByID(bankMock.Id.ToString());

            Assert.IsInstanceOfType(result, typeof(BankAccountReadModel));
            Assert.IsTrue(result.OwnerId == bankMock.OwnerId);
           


        }


    }
}
