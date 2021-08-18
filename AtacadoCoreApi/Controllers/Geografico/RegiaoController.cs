using Atacadocore.SERV.Geografico;
using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Geografico;
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
    [Route("api/geografico/regiao")]
    [ApiController]
    public class RegiaoController : GenericBaseController<RegiaoPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public RegiaoController(AtacadoContext contexto) : base(contexto)
        {
            this.servico = new RegiaoService(this.contexto);
        }


        /// <summary>
        /// Obtem todos os registro da tabela Regiao.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<RegiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }


        /// <summary>
        /// Obtem um registro por ID da tabela Regiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  RegiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }
        /// <summary>
        /// Tras os estados de uma determinada regiao.
        /// </summary>
        /// <param name="regiaoid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{regiaoid:int}/unidadesfederacao")]
        public List<UnidadesFederacaoPoco> GetEstado(int regiaoid)
        {
            UnidadesFederacaoService srv = new UnidadesFederacaoService(this.contexto);
            List<UnidadesFederacaoPoco> lista = srv.ObterTodos().Where(est => est.RegiaoID == regiaoid).ToList();

            return lista;
        }

        /// <summary>
        /// Adiciona um registro a tabela Regiao.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  RegiaoPoco Post([FromBody]RegiaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza um registro na tabela Regiao
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  RegiaoPoco Put(RegiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui um Registro por ID na tabela Regiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  RegiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}
