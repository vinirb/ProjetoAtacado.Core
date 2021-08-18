using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.POCO.Geografico
{
    public class RegiaoPoco
    {
        public int RegiaoID { get; set; }

        public string Descricao { get; set; }

        public string SiglaRegiao { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
