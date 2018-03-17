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
    public class ClientServices :IClientServices
    {
        private readonly IBankSystemContext dbContext;
        private readonly IMapper mapper;

        public ClientServices(IBankSystemContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddClient(ClientModel client)
        {
            if (client==null)
            {
                throw new ArgumentNullException("Fuck you bitch the, you can not new client that is NULL");
            }

            var clientToAdd = this.mapper.Map<Client>(client);

            this.dbContext.Clients.Add(clientToAdd);
            this.dbContext.SaveChanges();
                       

        }

        public IQueryable<ClientModel> GetClients()
        {
            return this.dbContext.Clients.ProjectTo<ClientModel>();
        }


    }
}
