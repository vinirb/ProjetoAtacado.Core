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
    public class UnidadesFederacaoMap : BaseMapping
    {
        public UnidadesFederacaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UnidadesFederacao, UnidadesFederacaoPoco>()
                .ForMember(ufs => ufs.DataInclusao, map => map.MapFrom(ufsp => ufsp.Datainsert));

                cfg.CreateMap<UnidadesFederacaoPoco, UnidadesFederacao>()
                .ForMember(ufs => ufs.Datainsert, map => map.MapFrom(ufsp => ufsp.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
