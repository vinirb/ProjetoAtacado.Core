using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.POCO.Estoque
{
    public class CategoriaPoco
    {
        public int CategoriaId { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
