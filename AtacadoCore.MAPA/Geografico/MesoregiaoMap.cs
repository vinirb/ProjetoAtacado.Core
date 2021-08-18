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
    public class MesoregiaoMap : BaseMapping
    {

        public MesoregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mesoregiao, MesoregiaoPoco>()
                .ForMember(msr => msr.DataInclusao, map => map.MapFrom(msrp => msrp.Datainsert));

                cfg.CreateMap<MesoregiaoPoco, Mesoregiao>()
                .ForMember(msr => msr.Datainsert, map => map.MapFrom(msrp => msrp.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }

    }
}
