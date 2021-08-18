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
    [Route("api/geografico/municipio")]
    [ApiController]
    public class MunicipioController : GenericBaseController<MunicipioPoco>
    {
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="contexto"></param>
        public MunicipioController(AtacadoContext contexto) : base(contexto)
        {
            this.servico = new MunicipioService(this.contexto);
        }

        

        /// <summary>
        /// Obtem todos os registros pela Sigla do Estado na tabela Municipio.
        /// </summary>
        /// <param name="siglaUF">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("siglaUF")]
        public new List<MunicipioPoco> GetEstado(string siglaUF)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> lista = this.servico.ObterTodos().Where(mun => mun.SiglaUF == siglaUF).ToList();

            return lista;
        }


        /// <summary>
        /// Obtem um registro por ID na tabela Municipio.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  MunicipioPoco Get(int id)
        {
            return this.servico.Obter(id);
        }


        /// <summary>
        /// Adiciona um registro a tabela Municipio.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  MunicipioPoco Post([FromBody]MunicipioPoco poco)
        {
            return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza um registro na tabela Municipio.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  MunicipioPoco Put(MunicipioPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui um registro na tabela Municipio.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public  MunicipioPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
