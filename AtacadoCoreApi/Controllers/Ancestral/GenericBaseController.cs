using Atacadocore.SERV.Ancestral;
using AtacadoCore.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    
    public abstract class GenericBaseController<TPoco> : ControllerBase
        where TPoco : class
    {

        protected AtacadoContext contexto;

        protected IService<TPoco> servico;

       
        public GenericBaseController(AtacadoContext contexto)
        {
            this.contexto = contexto;
        }

    }
}
