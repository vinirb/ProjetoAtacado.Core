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
    [Route("api/geografico/unidadesfederacao")]
    [ApiController]
    public class UnidadesFederacaoController : GenericBaseController<UnidadesFederacaoPoco>
    {
        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        /// <param name="contexto"></param>
        public UnidadesFederacaoController(AtacadoContext contexto) : base(contexto)
        {
            this.servico = new UnidadesFederacaoService(this.contexto);
        }
        /// <summary>
        /// Obtem todos os registros da tabela UnidadesFederacao.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<UnidadesFederacaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }


        /// <summary>
        /// Obtem o registro por ID na tabela UnidadeFederacao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  UnidadesFederacaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Tras as mesoregioes de um estado.
        /// </summary>
        /// <param name="mesoid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesoid:int}/mesoreigao")]
        public List<MesoregiaoPoco> GetMesoreigao(int mesoid)
        {
            MesoregiaoService srv = new MesoregiaoService(this.contexto);
            List<MesoregiaoPoco> lista = srv.ObterTodos().Where(mes => mes.UFID == mesoid).ToList();

            return lista;
        }

        /// <summary>
        /// Tras os municipios de um determinado estado;
        /// </summary>
        /// <param name="estadoid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{estadoid:int}/municipio")]
        public List<MunicipioPoco> GetMunicipio(int estadoid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> lista = srv.ObterTodos().Where(mun => mun.UFID == estadoid).ToList();

            return lista;
        }


        /// <summary>
        /// Adiciona um registro a tabela UnidadesFederacao.
        /// </summary>
        /// <param name="poco">objeto a ser inserido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  UnidadesFederacaoPoco Post([FromBody]UnidadesFederacaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }


        /// <summary>
        /// Atualiza o registro na tabela UnidadesFederacao.
        /// </summary>
        /// <param name="poco">objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public  UnidadesFederacaoPoco Put(UnidadesFederacaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }


        /// <summary>
        /// Exclui um registro por ID da tabela UnidadesFederacao.
        /// </summary>
        /// <param name="id">chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public  UnidadesFederacaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
