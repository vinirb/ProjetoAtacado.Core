using Atacadocore.SERV.Ancestral;
using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Geografico;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.POCO.Geografico;
using AtacadoCore.REPO.Geografico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacadocore.SERV.Geografico
{
    public class MunicipioService : GenericService<DbContext, Municipio, CategoriaPoco>, IService<MunicipioPoco>
    {


        public MunicipioService(DbContext contexto)
        {
            this.repositorio = new MunicipioRepository(contexto);
            this.mapa = new MunicipioMap();
        }

        public IEnumerable<MunicipioPoco> ObterTodos()
        {
            List<Municipio> lista = this.repositorio.Browse().ToList();
            List<MunicipioPoco> listaPoco = this.mapa.GetMapper.Map<List<MunicipioPoco>>(lista);

            return listaPoco;
        }
        public MunicipioPoco Obter(int id)
        {
            Municipio dominio = this.repositorio.Read(mun => mun.MunicipioId == id);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(dominio);

            return novoPoco;
        }
        public MunicipioPoco Incluir(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio nova = this.repositorio.Add(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(nova);

            return novoPoco;
        }

        public MunicipioPoco Atualizar(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio alterada = this.repositorio.Edit(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(alterada);

            return novoPoco;
        }

        public MunicipioPoco Excluir(int id)
        {
            Municipio mun = this.repositorio.Read(mn => mn.Ufid == id);
            Municipio excluida = this.repositorio.Delete(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(excluida);

            return novoPoco;
        }

    }
}
