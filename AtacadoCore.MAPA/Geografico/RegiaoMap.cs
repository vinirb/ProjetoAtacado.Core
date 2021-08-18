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
    public class RegiaoMap : BaseMapping
    {
        public RegiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Regiao, RegiaoPoco>()
                .ForMember(reg => reg.DataInclusao, map => map.MapFrom(rgp => rgp.Datainsert));

                cfg.CreateMap<RegiaoPoco, Regiao>()
                .ForMember(reg => reg.Datainsert, map => map.MapFrom(rgp => rgp.DataInclusao));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
