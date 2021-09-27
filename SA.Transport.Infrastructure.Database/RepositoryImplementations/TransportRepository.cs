using Microsoft.EntityFrameworkCore;
using SA.Transport.Core.Application.Common.Filters;
using SA.Transport.Core.Application.Common.Paging;
using SA.Transport.Core.Application.RepositoryInterfaces;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SA.Transport.Infrastructure.Database.RepositoryImplementations
{
    public class TransportRepository : Repository<Core.Domain.Model.Transport>, ITransportRepository
    {
        public TransportRepository(TransportDBContext context) : base(context)
        {

        }
        public new Core.Domain.Model.Transport GetById(Guid id) => context.Transports
                .Include(x => x.Color)
                .Include(x => x.FuelTypes)
                    .ThenInclude(x => x.FuelType)
                .Include(x => x.Owners)
                    .ThenInclude(x => x.Person)
                .FirstOrDefault(x => x.Id == id);

        public void AddOwner(Guid transportId, Person person)
        {
            var transport = context.Transports.Find(transportId);
            if (transport != null)
            {
                transport.Owners.Add(new TransportOwner { Person = person, TransportId = transportId, StartDate = DateTime.Now });
                context.SaveChanges();
            }
        }

        public void DeleteOwner(Guid transportId, Guid personId)
        {
            var transportOwner = context.TransportOwners.FirstOrDefault(x => x.TransportId == transportId && x.PersonId == personId);
            context.TransportOwners.Remove(transportOwner);
            context.SaveChanges();
        }

        public IEnumerable<Person> GetOwners(Guid transportId)
        {
            return context.TransportOwners
                    .Include(x => x.Person)
                    .Where(x => x.TransportId == transportId)
                    .Select(x => x.Person);
        }

        public IEnumerable<Core.Domain.Model.Transport> GetAll(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", TransportFilter transportFilter = null)
        {
            return context.Transports
                 .Include(x => x.Color)
                 .Include(x => x.FuelTypes)
                     .ThenInclude(x => x.FuelType)
                 .Include(x => x.Owners)
                     .ThenInclude(x => x.Person)
                 .ApplyFilterParameters(transportFilter)
                 .ApplyOrderParameters(orderBy)
                 .TakePage(pageRequest, out pageResponse)
                 .ToList();
        }
    }
}
