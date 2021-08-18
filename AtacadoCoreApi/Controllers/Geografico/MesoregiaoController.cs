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
    [Route("api/geografico/mesoregiao")]
    [ApiController]
    public class MesoregiaoController : GenericBaseController<MesoregiaoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public MesoregiaoController(AtacadoContext contexto) : base(contexto)
        {
            
            this.servico = new MesoregiaoService(this.contexto);
        }
        /// <summary>
        /// tras as microregioes de uma mesoregiao.
        /// </summary>
        /// <param name="microid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{microid:int}/microregiao")]
        public List<MicroregiaoPoco> GetMicroregiao(int microid)
        {
            MicroregiaoService srv = new MicroregiaoService(this.contexto);
            List<MicroregiaoPoco> lista = srv.ObterTodos().Where(mic => mic.MesoregiaoID == microid).ToList();

            return lista;
        }


        /// <summary>
        /// Obtem todos os registros da tabela Mesoregiao.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<MesoregiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Obtem um registro por ID na tabela Mesoregiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  MesoregiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }


        /// <summary>
        /// Adiciona um registro na tabela Mesoregiao.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  MesoregiaoPoco Post([FromBody]MesoregiaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }
        
        /// <summary>
        /// Atualiza um registro da tabela Mesoregiao.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  MesoregiaoPoco Put(MesoregiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Exclui um registro por ID na tabela Mesoregiao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  MesoregiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
