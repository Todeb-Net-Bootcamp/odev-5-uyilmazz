using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TModel, TContext> : IEntityRepository<TModel>
         where TModel : class, IModel, new()
        where TContext : DbContext, new()
    {
        public void Add(TModel model)
        {
            using (TContext context = new TContext())
            {
                var entityToAdd = context.Entry(model);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TModel model)
        {
            using (TContext context = new TContext())
            {
                var entityToAdd = context.Entry(model);
                entityToAdd.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TModel Get(Expression<Func<TModel, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TModel>().SingleOrDefault(filter);
            }
        }

        public List<TModel> GetAll(Expression<Func<TModel, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TModel>().ToList() : context.Set<TModel>().Where(filter).ToList();
            }
        }

        public void Update(TModel model)
        {
            using (TContext context = new TContext())
            {
                var entityToAdd = context.Entry(model);
                entityToAdd.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
