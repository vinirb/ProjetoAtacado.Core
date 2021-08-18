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
    public class ProdutoMap : BaseMapping
    {
        public ProdutoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoPoco>()
                .ForMember(dst => dst.ProdutoID, map => map.MapFrom(src => src.Produtoid))
                .ForMember(dst => dst.CategoriaID, map =>map.MapFrom(src=> src.Catid))
                .ForMember(dst => dst.SubCategoriaID, map => map.MapFrom(src => src.Subcatid))
                .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.Datainsert));


                cfg.CreateMap<ProdutoPoco, Produto>()
                .ForMember(dst => dst.Produtoid, map => map.MapFrom(src => src.ProdutoID))
                .ForMember(dst => dst.Catid, map => map.MapFrom(src => src.CategoriaID))
                .ForMember(dst => dst.Subcatid, map => map.MapFrom(src => src.SubCategoriaID))
                .ForMember(dst => dst.Datainsert, map => map.MapFrom(src => src.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
