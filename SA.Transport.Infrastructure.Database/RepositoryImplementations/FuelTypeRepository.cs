using SA.Transport.Core.Application.RepositoryInterfaces;
using SA.Transport.Core.Domain.Model;

namespace SA.Transport.Infrastructure.Database.RepositoryImplementations
{
    public class FuelTypeRepository : Repository<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(TransportDBContext context) : base(context)
        {
        }

    }
}
