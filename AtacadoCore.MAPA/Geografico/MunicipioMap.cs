using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.POCO.Geografico;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Geografico
{
    public class MunicipioMap : BaseMapping
    {
        public MunicipioMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Municipio, MunicipioPoco>();

                cfg.CreateMap<MunicipioPoco, Municipio>();


            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
