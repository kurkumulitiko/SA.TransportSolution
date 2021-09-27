using SA.Transport.Core.Application.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Core.Application
{
    public interface IUnitOfWork
    {
        public IFuelTypeRepository FuelTypeRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public ITransportRepository TransportRepository { get; }
    }
}
