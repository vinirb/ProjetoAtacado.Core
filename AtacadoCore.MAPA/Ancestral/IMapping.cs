using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Ancestral
{
    public interface IMapping
    {
        IMapper GetMapper { get; set; }
    }
}
