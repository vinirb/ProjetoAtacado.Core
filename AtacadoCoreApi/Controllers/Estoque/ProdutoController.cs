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
    [Route("api/estoque/produto")]
    [ApiController]
    public class ProdutoController : GenericBaseController<ProdutoPoco>
    {

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        /// <param name="contexto"></param>
        public ProdutoController(AtacadoContext contexto) : base(contexto)
        {
           
            this.servico = new ProdutoService(this.contexto);
        }


        /// <summary>
        /// Obtem um registro por ID na tabela Produto.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  ProdutoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }


        /// <summary>
        /// Adiciona um registro na tabela Produto.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  ProdutoPoco Post(ProdutoPoco poco)
        {
           return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza um Registro na tabela Produto.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  ProdutoPoco Put(ProdutoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui um registro por ID na tabela Produto.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  ProdutoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
