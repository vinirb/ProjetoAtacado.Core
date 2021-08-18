using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.POCO.Estoque;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Estoque
{
    public class CategoriaMap : BaseMapping
    {
        public CategoriaMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Categorium, CategoriaPoco>()
                .ForMember(dst => dst.CategoriaId, map => map.MapFrom(src => src.Catid))
                .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.Datainsert));

                cfg.CreateMap<CategoriaPoco, Categorium>()
                .ForMember(dst => dst.Catid, map => map.MapFrom(src => src.CategoriaId))
                .ForMember(dst => dst.Datainsert, map => map.MapFrom(src =>
                (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
