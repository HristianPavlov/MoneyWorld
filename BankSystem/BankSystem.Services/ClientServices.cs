using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankSystem.Data.Contracts;
using BankSystem.DTO.ClientModels;
using BankSystem.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IBankSystemContext dbContext;
        private readonly IMapper mapper;

        public ClientServices(IBankSystemContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //public void AddClient(ClientAddModel client)
        //{
        //    if (client == null)
        //    {
        //        throw new ArgumentNullException("Fuck you bitch the, you can not add new client that is NULL");
        //    }

        //    var clientToAdd = this.mapper.Map<Client>(client);

        //    this.dbContext.Clients.Add(clientToAdd);
        //    this.dbContext.SaveChanges();


        //}

        public IEnumerable<ClientReadModel> GetClients()
        {
            return this.dbContext.Users.ProjectTo<ClientReadModel>();
        }

        public ClientReadModel GetClientByID(string ID)
        {
            var customer = this.dbContext.Users.ProjectTo<ClientReadModel>();

            //from e in this.dbContext.Clients
            //where e.Id == ID
            //select e;
            // .ProjectTo<ClientReadModel>().FirstOrDefault()
            // .FirstOrDefault()
            return customer.Where(x=>x.Id==ID).FirstOrDefault();
            //this.dbContext.Clients.Where(x=>x.Id==ID).ProjectTo<ClientReadModel>().FirstOrDefault();
        }


        public ClientReadModel DeleteClientByID(string ID)
        {
            var costumers = from e in this.dbContext.Users
                            where e.Id == ID
                            select e;

            costumers.FirstOrDefault().IsDeleted = true;


            this.dbContext.SaveChanges();

            return costumers.ProjectTo<ClientReadModel>().FirstOrDefault();

        }

    }
}
