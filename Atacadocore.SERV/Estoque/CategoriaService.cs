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
    public class CategoriaService : GenericService<DbContext, Categorium, CategoriaPoco>, IService<CategoriaPoco>
    {


        public CategoriaService(DbContext contexto)
        {
            this.repositorio = new CategoriaRepository(contexto);
            this.mapa = new CategoriaMap();
        }

        public CategoriaPoco Obter(int id)
        {
            Categorium dominio = this.repositorio.Read(cat => cat.Catid == id);
            CategoriaPoco poco = this.mapa.GetMapper.Map<CategoriaPoco>(dominio);

            return poco;
        }
        public IEnumerable<CategoriaPoco> ObterTodos()
        {
            List<Categorium> lista = this.repositorio.Browse().ToList();
            List<CategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<CategoriaPoco>>(lista);

            return listaPoco;
        }

        public CategoriaPoco Incluir(CategoriaPoco poco)
        {
            Categorium cat = this.mapa.GetMapper.Map<Categorium>(poco);
            Categorium nova = this.repositorio.Add(cat);
            CategoriaPoco novoPoco = this.mapa.GetMapper.Map<CategoriaPoco>(nova);


            return novoPoco;
        }

        public CategoriaPoco Atualizar(CategoriaPoco poco)
        {
            Categorium cat = this.mapa.GetMapper.Map<Categorium>(poco);
            Categorium alterada = this.repositorio.Edit(cat);
            CategoriaPoco novoPoco = this.mapa.GetMapper.Map<CategoriaPoco>(alterada);

            return novoPoco;
        }

        public CategoriaPoco Excluir(int id)
        {
            Categorium cat = this.repositorio.Read(ct => ct.Catid == id);
            Categorium excluida = this.repositorio.Delete(cat);
            CategoriaPoco novoPoco = this.mapa.GetMapper.Map<CategoriaPoco>(excluida);

            return novoPoco;
        }

    }
}
