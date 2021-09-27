using SA.Transport.Core.Application;
using SA.Transport.Core.Application.RepositoryInterfaces;
using SA.Transport.Infrastructure.Database.RepositoryImplementations;

namespace SA.Transport.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private IFuelTypeRepository fuelTypeRepository;
        private IPersonRepository personRepository;
        private ITransportRepository transportRepository;

        private readonly TransportDBContext context;
        public UnitOfWork(TransportDBContext context)
        {
            this.context = context;
        }

        public IFuelTypeRepository FuelTypeRepository => fuelTypeRepository ??= new FuelTypeRepository(context);
        public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);
        public ITransportRepository TransportRepository => transportRepository ??= new TransportRepository(context);
    }
}
