using Atacadocore.SERV.Geografico;
using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Geografico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers.Geografico
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/geografico/microregiao")]
    [ApiController]
    public class MicroregiaoController : GenericBaseController<MicroregiaoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public MicroregiaoController(AtacadoContext contexto) : base(contexto)
        {
            this.servico = new MicroregiaoService(this.contexto);
        }
        /// <summary>
        /// Obtem todos os registros da tabela Microregiao.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<MicroregiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }


        /// <summary>
        /// Obtem o registro por ID na tabela Microregiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  MicroregiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }


        /// <summary>
        /// Adiciona um registro a tabela Microregiao.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  MicroregiaoPoco Post([FromBody]MicroregiaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza um registro na tabela Microregiao.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  MicroregiaoPoco Put(MicroregiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui um registro por ID na tabela Microregiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  MicroregiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
