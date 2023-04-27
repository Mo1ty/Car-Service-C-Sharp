using CarServiceApp.EFCore;
using CarServiceApp.EFCore.common;
using CarServiceApp.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository.common
{
    internal abstract class GenericRepository<TEntity>
    {
        private CarServiceContext context = ContextConfiguration.Context;

        public void addEntity<TEntity>(TEntity tEntity) where TEntity : class, IEntity
        {
            try
            {
                context.Set<TEntity>().Add(tEntity);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> findAll<TEntity>() where TEntity : class, IEntity
        {
            return (from e in context.Set<TEntity>() select e).ToList();
        }

        public bool existsById<TEntity>(Guid Id) where TEntity : class, IEntity
        {
            List<TEntity> resultList = (from c in context.Set<TEntity>() where c.Id == Id select c).ToList();
            return resultList.Count != 0 ? true : false;
        }

        public TEntity? findById<TEntity>(Guid Id) where TEntity : class, IEntity
        {
            List<TEntity> resultList = (from c in context.Set<TEntity>()
                            where c.Id == Id
                            select c).ToList();
            if (resultList.Count == 1)
                return resultList[0];
            else if (resultList.Count > 1)
                throw new Exception($"Multiple items of type \"{resultList[0].GetType()}\" with this ID found in the database!");
            return null;
        }
    }
}
