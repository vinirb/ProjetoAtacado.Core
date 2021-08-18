using Atacadocore.SERV.Ancestral;
using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Estoque;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.REPO.Estoque;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacadocore.SERV.Estoque
{
    public class ProdutoService : GenericService<DbContext, Produto, CategoriaPoco>, IService<ProdutoPoco>
    {


        public ProdutoService(DbContext contexto)
        {
            this.repositorio = new ProdutoRepository(contexto);
            this.mapa = new ProdutoMap();
        }

        public IEnumerable<ProdutoPoco> ObterTodos()
        {
            List<Produto> lista = this.repositorio.Browse().ToList();
            List<ProdutoPoco> listaPoco = this.mapa.GetMapper.Map<List<ProdutoPoco>>(lista);

            return listaPoco;
        }

        public ProdutoPoco Obter(int id)
        {
            Produto dominio = this.repositorio.Read(prod => prod.Produtoid == id);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(dominio);

            return novoPoco;
        }

        public ProdutoPoco Incluir(ProdutoPoco poco)
        {
            Produto prod = this.mapa.GetMapper.Map<Produto>(poco);
            Produto adicionada = this.repositorio.Add(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(adicionada);

            return novoPoco;
        }

        public ProdutoPoco Atualizar(ProdutoPoco poco)
        {
            Produto prod = this.mapa.GetMapper.Map<Produto>(poco);
            Produto atualizada = this.repositorio.Edit(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(atualizada);

            return novoPoco;
        }

        public ProdutoPoco Excluir(int id)
        {
            Produto prod = this.repositorio.Read(pd => pd.Produtoid == id);
            Produto excluida = this.repositorio.Delete(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(excluida);

            return novoPoco;
        }


    }
}
