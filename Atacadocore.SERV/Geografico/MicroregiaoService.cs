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
    public class MicroregiaoService : GenericService<DbContext, Microregiao, CategoriaPoco>, IService<MicroregiaoPoco>
    {

        public MicroregiaoService(DbContext contexto)
        {
            this.repositorio = new MicroregiaoRepository(contexto);
            this.mapa = new MicroregiaoMap();
        }
        public IEnumerable<MicroregiaoPoco> ObterTodos()
        {
            List<Microregiao> lista = this.repositorio.Browse().ToList();
            List<MicroregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MicroregiaoPoco>>(lista);

            return listaPoco;
        }

        public MicroregiaoPoco Obter(int id)
        {
            Microregiao mic = this.repositorio.Read(mc => mc.MicroregiaoId == id);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(mic);

            return novoPoco;

        }

        public MicroregiaoPoco Incluir(MicroregiaoPoco poco)
        {
            Microregiao mic = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao adicionada = this.repositorio.Add(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(adicionada);

            return novoPoco;
        }

        public MicroregiaoPoco Atualizar(MicroregiaoPoco poco)
        {
            Microregiao mic = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao atualizada = this.repositorio.Edit(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(atualizada);

            return novoPoco;
        }

        public MicroregiaoPoco Excluir(int id)
        {
            Microregiao mic = this.repositorio.Read(mc => mc.MicroregiaoId == id);
            Microregiao excluida = this.repositorio.Delete(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(excluida);

            return novoPoco;
        }

    }
}
