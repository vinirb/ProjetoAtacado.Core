using Atacadocore.SERV.Ancestral;
using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Geografico;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.POCO.Geografico;
using AtacadoCore.REPO.Geografico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacadocore.SERV.Geografico
{
    public class RegiaoService : GenericService<DbContext, Regiao, CategoriaPoco>, IService<RegiaoPoco>
    {


        public RegiaoService(DbContext contexto)
        {
            this.repositorio = new RegiaoRepository(contexto);
            this.mapa = new RegiaoMap();
        }

        public IEnumerable<RegiaoPoco> ObterTodos()
        {
            List<Regiao> lista = this.repositorio.Browse().ToList();
            List<RegiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<RegiaoPoco>>(lista);

            return listaPoco;
        }


        public RegiaoPoco Obter(int id)
        {
            Regiao reg = this.repositorio.Read(rg => rg.RegiaoId == id);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(reg);

            return novoPoco;
        }

        public RegiaoPoco Incluir(RegiaoPoco poco)
        {
            Regiao rg = this.mapa.GetMapper.Map<Regiao>(poco);
            Regiao adicionada = this.repositorio.Add(rg);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(adicionada);

            return novoPoco;
        }

        public RegiaoPoco Atualizar(RegiaoPoco poco)
        {
            Regiao rg = this.mapa.GetMapper.Map<Regiao>(poco);
            Regiao atualizada = this.repositorio.Edit(rg);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(atualizada);

            return novoPoco;
        }

        public RegiaoPoco Excluir(int id)
        {
            Regiao rg = this.repositorio.Read(reg => reg.RegiaoId == id);
            Regiao excluida = this.repositorio.Delete(rg);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(excluida);

            return novoPoco;
        }

    }
}
