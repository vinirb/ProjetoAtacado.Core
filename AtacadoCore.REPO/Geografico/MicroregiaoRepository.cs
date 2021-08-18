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
    public class MicroregiaoRepository : GenericRepository<DbContext, Microregiao>
    {
        public MicroregiaoRepository(DbContext contexto) : base(contexto)
        {

        }
    }
}
