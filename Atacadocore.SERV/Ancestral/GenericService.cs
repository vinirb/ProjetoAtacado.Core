using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.REPO.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacadocore.SERV.Ancestral
{
    public abstract class GenericService<TContext, TDomain, TPoco> : IDisposable
         where TContext : DbContext
         where TDomain : class
         where TPoco : class
    {
        protected GenericRepository<TContext, TDomain> repositorio;

        protected BaseMapping mapa;


        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }



    }
}
