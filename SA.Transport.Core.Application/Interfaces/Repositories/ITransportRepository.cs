using SA.Transport.Core.Application.Common.Filters;
using SA.Transport.Core.Application.Common.Paging;
using SA.Transport.Core.Domain.Model;
using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Application.RepositoryInterfaces
{
    public interface ITransportRepository : IRepository<Domain.Model.Transport>
    {

        void AddOwner(Guid transportId, Person person);
        void DeleteOwner(Guid transportId, Guid personId);
        IEnumerable<Person> GetOwners(Guid transportId);
        IEnumerable<Domain.Model.Transport> GetAll(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", TransportFilter transportFilter = null);

    }
}
