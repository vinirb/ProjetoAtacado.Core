using AtacadoCore.DAL.Models;
using AtacadoCore.REPO.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Geografico
{
    public class MesoregiaoRepository : GenericRepository<DbContext, Mesoregiao>
    {
        public MesoregiaoRepository(DbContext contexto) : base(contexto)
        {

        }
    }
}
