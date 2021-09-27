using SA.Transport.Core.Application.RepositoryInterfaces;
using SA.Transport.Core.Domain.Model;

namespace SA.Transport.Infrastructure.Database.RepositoryImplementations
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(TransportDBContext context) : base(context)
        {

        }

    }
}
