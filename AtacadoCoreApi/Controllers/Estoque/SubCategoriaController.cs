using Atacadocore.SERV.Estoque;
using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/subcategoria")]
    [ApiController]
    public class SubCategoriaController : GenericBaseController<SubCategoriaPoco>
    {
        

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        /// <param name="contexto"></param>
        public SubCategoriaController(AtacadoContext contexto) : base(contexto)
        {
           
            this.servico = new SubCategoriaService(this.contexto);
        }

        /// <summary>
        /// Obtem todos os registros da tabela SubCategoria.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<SubCategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }
        /// <summary>
        /// Tras os produtos da subcategoria selecionada.
        /// </summary>
        /// <param name="subcatid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subcatid:int}/produtos")]
        public List<ProdutoPoco> GetProd(int subcatid)
        {
            ProdutoService srv = new ProdutoService(this.contexto);
            List<ProdutoPoco> lista = srv.ObterTodos().Where(prd => prd.SubCategoriaID == subcatid).ToList();

            return lista;
        }

        /// <summary>
        /// Obtem o resgitro por ID na tabela Subcategoria.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  SubCategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }


        /// <summary>
        /// Adiciona um novo Registro a Tabela Subcategoria.
        /// </summary> 
        /// <param name="poco">objeto a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  SubCategoriaPoco Post(SubCategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza um registro na tabela SubCategoria.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  SubCategoriaPoco Put(SubCategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui  um registro da tabela Subcategoria.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  SubCategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
