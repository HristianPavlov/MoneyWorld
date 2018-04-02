using BankSystem.DTO;
using System.Collections.Generic;

namespace BankSystem.Services
{
    public interface IJsonReader
    {

        IEnumerable<BankAccountAddAspModel> BankAccountFromJson(string file);
       

    }
}