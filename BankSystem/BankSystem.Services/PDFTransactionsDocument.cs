using BankSystem.Common;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services
{
    public class PDFTransactionsDocument
    {
        private PDF pdfDoc;
        private ITransactionService service;

        public PDFTransactionsDocument(ITransactionService service, string path)
        {
            this.service = service;
            this.pdfDoc = new PDF(path);
        }

        public void CreateDocument(ClientModel clientModel)
        {
            this.pdfDoc.SetDefaultPageSettings();
            
            this.pdfDoc.CreateTable(typeof(TransactionInfoModel).GetProperties().Count(), 500, 50, 50, "All transaction of user");

            var transactions = service.GetTransactions(clientModel).ToList();

            var nameOfCols = transactions
                .FirstOrDefault()
                .GetType()
                .GetProperties()
                .Select(x => x.Name)
                .ToList();

            this.pdfDoc.PopulateRow(nameOfCols);

            for (int i = 0; i < transactions.Count; i++)
            {
                var properties = transactions[i]
                    .GetType()
                    .GetProperties();

                var info = new List<string>();

                foreach (var p in properties)
                {
                    var value = transactions[i]
                        .GetType()
                        .GetProperty(p.Name)
                        .GetValue(transactions[i], null);

                    info.Add(value.ToString());
                }

                this.pdfDoc.PopulateRow(info);
            }

            this.pdfDoc.AddTable();
            this.pdfDoc.Close();
        }
    }
}
