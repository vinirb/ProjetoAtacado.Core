using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Ancestral
{
    public abstract class BaseMapping : IMapping
    {
        public IMapper GetMapper { get; set; }
    }
}
