using Atacadocore.SERV.Estoque;
using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste
{
    public class Teste
    {
        public void Executar()
        {
            AtacadoContext contexto = new AtacadoContext();

            ProdutoService servico = new ProdutoService(contexto);

            List<ProdutoPoco> lista = servico.ObterTodos().ToList();

            Console.WriteLine("Listando Categorias");
            foreach (var item in lista)
            {
                Console.WriteLine("ProdutoID: {0}",item.ProdutoID);
                Console.WriteLine("SubcategoriaID: {0}", item.SubCategoriaID);
                Console.WriteLine("CategoriaID: {0}",item.CategoriaID);
                Console.WriteLine("Descrição: {0}",item.Descricao);
                Console.WriteLine("DataInclusao: {0}",item.DataInclusao);
                Console.WriteLine("####################################");
            }

            Console.ReadLine();
        }
    }
}
