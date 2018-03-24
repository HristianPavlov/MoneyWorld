using AutoMapper;
using BankSystem.ConsoleClient.AutofacModules;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.ConsoleClient.Controllers
{
    public class ClientController
    {
        private readonly IClientServices clientService;
        private readonly IMapper mapper;

        public ClientController(IClientServices ClientService, IMapper mapper)
        {
            this.clientService = ClientService;
            this.mapper = mapper;
        }

        public void AddClient(string userName, string firstName, string lastName, string password)
        {
            if (userName == null || firstName == null || lastName == null || password == null)
            {

                throw new ArgumentNullException("bitch, you can't add null stuff, check your shit");
            }

            var client = new ClientAddModel
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Password = password

            };

            this.clientService.AddClient(client);

        }
        public IEnumerable<ClientReadModel> GetAll()
        {
            var posts = this.clientService.GetClients();

            return posts;
        }




    }
}
