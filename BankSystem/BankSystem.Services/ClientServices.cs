using AutoMapper;
using BankSystem.Data.Contracts;
using BankSystem.Services.Contracts;

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

        //public IEnumerable<ClientReadModel> GetClients()
        //{
        //    return this.dbContext.Clients.ProjectTo<ClientReadModel>();
        //}

        //public ClientReadModel GetClientByID(int ID)
        //{
        //    var customer = this.dbContext.Clients.ProjectTo<ClientReadModel>();

        //        //from e in this.dbContext.Clients
        //        //           where e.Id == ID
        //        //           select e;
        //       // .ProjectTo<ClientReadModel>().FirstOrDefault()
        //      // .FirstOrDefault()
        //    return customer.FirstOrDefault();
        //    //this.dbContext.Clients.Where(x=>x.Id==ID).ProjectTo<ClientReadModel>().FirstOrDefault();
        //}


        //public ClientReadModel DeleteClientByID(int ID)
        //{
        //    var costumers = from e in this.dbContext.Clients
        //                    where e.Id == ID
        //                    select e;

        //    costumers.FirstOrDefault().IsDeleted = true;


        //    this.dbContext.SaveChanges();

        //    return costumers.ProjectTo<ClientReadModel>().FirstOrDefault();

        //}

    }
}
