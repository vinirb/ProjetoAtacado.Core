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
    public class MunicipioRepository : GenericRepository<DbContext, Municipio>
    {
        public MunicipioRepository(DbContext contexto) : base(contexto)
        { }
    }
}
