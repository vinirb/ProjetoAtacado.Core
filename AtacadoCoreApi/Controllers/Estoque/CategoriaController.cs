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
    [Route("api/estoque/categoria")]
    [ApiController]
    public class CategoriaController : GenericBaseController<CategoriaPoco>
    {
        
        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        public CategoriaController(AtacadoContext contexto) : base(contexto)
        {

            this.servico = new CategoriaService(this.contexto);
        }
        /// <summary>
        /// Obtem todos os registros na tabela Categoria.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<CategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }


        /// <summary>
        /// Obtem as subcategoria referente a ID da Categoria.
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        public List<SubCategoriaPoco> GetSubCategoria(int catid)
        {
            SubCategoriaService srv = new SubCategoriaService(this.contexto);
            List<SubCategoriaPoco> lista = srv.ObterTodos().Where(sub => sub.CategoriaID == catid).ToList();

            return lista;
        }


        /// <summary>
        /// Obtem um registro por ID na tabela Categoria.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  CategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }
       

        /// <summary>
        /// Adiciona um registro a tabela Categoria.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  CategoriaPoco Post(CategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }

       

        /// <summary>
        /// Atualiza o registro na tabela Categoria.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  CategoriaPoco Put(CategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Exclui o registro por ID na tabela Categoria. 
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  CategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
