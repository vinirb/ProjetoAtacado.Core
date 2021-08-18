using AtacadoCore.DAL.Models;
using AtacadoCore.REPO.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Estoque
{
    public class SubCategoriaRepository : GenericRepository<DbContext, Subcategorium>
    {
        public SubCategoriaRepository(DbContext contexto) : base(contexto)
        { }
    }
}
