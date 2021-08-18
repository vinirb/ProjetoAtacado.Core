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
    public class MicroregiaoMap : BaseMapping
    {
        public MicroregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Microregiao, MicroregiaoPoco>()
                .ForMember(mcr => mcr.DataInclusao, map => map.MapFrom(mcrp => mcrp.Datainsert));

                cfg.CreateMap<MicroregiaoPoco, Microregiao>()
                .ForMember(mcr => mcr.Datainsert, map => map.MapFrom(mcrp => mcrp.DataInclusao));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
