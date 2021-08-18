using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Ancestral
{
    public abstract class GenericRepository<TContext, TDomain> : IRepository<TDomain>
         where TContext : DbContext
         where TDomain : class
    {
        protected TContext contexto;

        public GenericRepository(TContext context)
        {
            this.contexto = context;
        }

        public IEnumerable<TDomain> Browse()
        {
            return this.Browsable().AsEnumerable();
        }

        public IQueryable<TDomain> Browsable()
        {
            return this.contexto.Set<TDomain>().AsQueryable();
        }

        public TDomain Read(Expression<Func<TDomain, bool>> parameters)
        {
            return this.Browsable().SingleOrDefault(parameters);
        }

        public TDomain Edit(TDomain instance)
        {
            this.contexto.Entry<TDomain>(instance).State = EntityState.Modified;
            this.contexto.SaveChanges();

            return instance;
        }

        public TDomain Add(TDomain instance)
        {
            this.contexto.Set<TDomain>().Add(instance);
            this.contexto.SaveChanges();

            return instance;
        }

        public TDomain Delete(TDomain instance)
        {
            this.contexto.Entry<TDomain>(instance).State = EntityState.Deleted;
            this.contexto.SaveChanges();

            return instance;
        }
    }
}
