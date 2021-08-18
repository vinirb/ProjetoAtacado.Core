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
    public class UnidadesFederacaoService : GenericService<DbContext, UnidadesFederacao, CategoriaPoco>, IService<UnidadesFederacaoPoco>
    {


        public UnidadesFederacaoService(DbContext contexto)
        {
            this.repositorio = new UnidadesFederacaoRepository(contexto);
            this.mapa = new UnidadesFederacaoMap();
        }

        public IEnumerable<UnidadesFederacaoPoco> ObterTodos()
        {
            List<UnidadesFederacao> lista = this.repositorio.Browse().ToList();
            List<UnidadesFederacaoPoco> listaPoco = this.mapa.GetMapper.Map<List<UnidadesFederacaoPoco>>(lista);

            return listaPoco;
        }

        public UnidadesFederacaoPoco Obter(int id)
        {
            UnidadesFederacao ufs = this.repositorio.Read(uf => uf.Ufid == id);
            UnidadesFederacaoPoco novoPoco = this.mapa.GetMapper.Map<UnidadesFederacaoPoco>(ufs);

            return novoPoco;
        }


        public UnidadesFederacaoPoco Incluir(UnidadesFederacaoPoco poco)
        {
            UnidadesFederacao ufs = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao adicionada = this.repositorio.Add(ufs);
            UnidadesFederacaoPoco novoPoco = this.mapa.GetMapper.Map<UnidadesFederacaoPoco>(adicionada);

            return novoPoco;
        }


        public UnidadesFederacaoPoco Atualizar(UnidadesFederacaoPoco poco)
        {
            UnidadesFederacao ufs = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao atualizada = this.repositorio.Edit(ufs);
            UnidadesFederacaoPoco novoPoco = this.mapa.GetMapper.Map<UnidadesFederacaoPoco>(atualizada);

            return novoPoco;
        }

        public UnidadesFederacaoPoco Excluir(int id)
        {
            UnidadesFederacao ufs = this.repositorio.Read(uf => uf.Ufid == id);
            UnidadesFederacao excluida = this.repositorio.Delete(ufs);
            UnidadesFederacaoPoco novoPoco = this.mapa.GetMapper.Map<UnidadesFederacaoPoco>(excluida);

            return novoPoco;
        }

    }
}
