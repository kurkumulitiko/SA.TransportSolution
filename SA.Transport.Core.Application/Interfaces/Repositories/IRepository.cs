using SA.Transport.Core.Application.Common.Paging;
using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Application.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "");        TEntity GetById(Guid id);
        void Create(TEntity entity);
        void Delete(Guid id);
        void Update(TEntity entity);

    }
}
