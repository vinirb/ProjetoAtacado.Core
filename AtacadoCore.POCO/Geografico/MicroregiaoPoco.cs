using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.POCO.Geografico
{
    public class MicroregiaoPoco
    {
        public int MicroregiaoID { get; set; }


        public string Descricao { get; set; }

        public int MesoregiaoID { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
