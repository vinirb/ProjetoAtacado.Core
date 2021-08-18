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
    public class SubCategoriaService : GenericService<DbContext, Subcategorium, CategoriaPoco>, IService<SubCategoriaPoco>
    {


        public SubCategoriaService(DbContext contexto)
        {
            this.repositorio = new SubCategoriaRepository(contexto);
            this.mapa = new SubCategoriaMap();
        }

        public IEnumerable<SubCategoriaPoco> ObterTodos()
        {
            List<Subcategorium> lista = this.repositorio.Browse().ToList();
            List<SubCategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubCategoriaPoco>>(lista);

            return listaPoco;
        }

        public SubCategoriaPoco Obter(int id)
        {
            Subcategorium dominio = this.repositorio.Read(sub => sub.Subcatid == id);
            SubCategoriaPoco poco = this.mapa.GetMapper.Map<SubCategoriaPoco>(dominio);

            return poco;
        }

        public SubCategoriaPoco Atualizar(SubCategoriaPoco poco)
        {
            Subcategorium subcat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium atualizada = this.repositorio.Edit(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(atualizada);

            return NovoPoco;
        }


        public SubCategoriaPoco Incluir(SubCategoriaPoco poco)
        {
            Subcategorium subcat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium adicionada = this.repositorio.Add(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(adicionada);

            return NovoPoco;
        }

        public SubCategoriaPoco Excluir(int id)
        {
            Subcategorium subcat = this.repositorio.Read(sub => sub.Catid == id);
            Subcategorium excluida = this.repositorio.Delete(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(excluida);

            return NovoPoco;
        }

    }
}
