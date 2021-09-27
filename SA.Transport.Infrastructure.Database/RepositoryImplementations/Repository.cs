using SA.Transport.Core.Application.Common.Paging;
using SA.Transport.Core.Application.RepositoryInterfaces;
using SA.Transport.Infrastructure.Database.Extensions;
using System;
using System.Collections.Generic;

namespace SA.Transport.Infrastructure.Database.RepositoryImplementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TransportDBContext context;
        public Repository(TransportDBContext transportDBContext)
        {
            context = transportDBContext;
        }



        public IEnumerable<TEntity> GetAll(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "") => context.Set<TEntity>()
                                              .ApplyOrderParameters(orderBy)
                                              .TakePage(pageRequest, out pageResponse);

        public TEntity GetById(Guid id) => context.Set<TEntity>().Find(id);

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tEntity = context.Set<TEntity>().Find(id);
            if (tEntity != null)
            {
                context.Set<TEntity>().Remove(tEntity);
                context.SaveChanges();
            }
        }
    }
}
