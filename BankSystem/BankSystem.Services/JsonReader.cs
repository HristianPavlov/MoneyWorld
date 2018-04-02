using BankSystem.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services
{
    public class JsonReader:IJsonReader
    {
        public IEnumerable<BankAccountAddAspModel> BankAccountFromJson(string file)
        {//@"D:\DESKTOP\"
            string json = File.ReadAllText(( file + ".json"));
            var jsonObj = JsonConvert.DeserializeObject<List<BankAccountAddAspModel>>(json);

            return jsonObj;
        }
    }
}
