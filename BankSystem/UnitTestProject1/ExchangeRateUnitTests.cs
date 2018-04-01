using System;
using BankSystem.Data;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.Models;
using BankSystem.Models.Enums;
using BankSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class ExchangeRateUnitTests
    {
        [TestMethod]
        public void Should_Return_ArgumentNullException_When_ExchangeModel_is_Null()
        {
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());


            var sut = new ExchangeRateService(effortContext);


            Assert.ThrowsException<ArgumentNullException>(() => sut.GetExchangeRate(null));

        }

        [TestMethod]
        public void Should_Return_ArgumentNullException_When_Exchange_is_Null()
        {
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());


            var sut = new ExchangeRateService(effortContext);


            var exchange = new ExchangeRateModel()
            {
                FromCurrency = (Currency)840,
                ToCurrency = (Currency)986
            };



            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.GetExchangeRate(exchange));

        }
        [TestMethod]
        public void Should_Return_1_When_The_Same_Currency_is_used()
        {
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());


            var sut = new ExchangeRateService(effortContext);


            var exchange = new ExchangeRateModel()
            {
                FromCurrency = (Currency)840,
                ToCurrency = (Currency)840
            };



            //Act & Assert
            Assert.IsTrue(sut.GetExchangeRate(exchange) == 1);

        }

        [TestMethod]
        public void Should_Return_the_expected_exchange()
        {
            var effortContext = new BankSystemContext(Effort.DbConnectionFactory.CreateTransient());

            
        
            var exchangeCheck = new ExchangeRateModel()
            {
                FromCurrency = (Currency)840,
                ToCurrency = (Currency)975,

            };

            var exchangeAdd = new ExchangeRate()
            {
                FromCurrency = (Currency)840,
                ToCurrency = (Currency)975,
                Rate = 0.5m,
                IsDeleted = false
            };


            effortContext.ExchangeRates.Add(exchangeAdd);
            effortContext.SaveChanges();

            var sut = new ExchangeRateService(effortContext);
            //Act & Assert
            Assert.IsTrue(sut.GetExchangeRate(exchangeCheck)==0.5m);

        }

    }
}
