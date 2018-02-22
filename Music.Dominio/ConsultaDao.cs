using Music.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dominio
{
    public class ConsultaDao
    {
        private lojaMusicaEntities contexto;

        public ConsultaDao()
        {
            contexto = new lojaMusicaEntities();
        }

        public List<Consulta> TipoConsulta()
        {

            var query = new List<Consulta>()
            {
                new Consulta() { ConsultaId = 1, Descricao = "Faixa mais vendida" },
                new Consulta() { ConsultaId = 2, Descricao = "Faixa menos vendida" },
                new Consulta() { ConsultaId = 3, Descricao = "Artista mais vendido" },
                new Consulta() { ConsultaId = 4, Descricao = "Artista menos vendido" }
            };

            return query;
        }

        public void getResultado(int id)
        {
            contexto.Database.Log = Console.WriteLine;

            var vendas = (from nf in contexto.ItemNotaFiscal
                          group nf by nf.FaixaId into g
                          let maxVenda = g.Max(p => p.Quantidade)
                          select new { nfaixa = g.Key, total = g.Where(p=>p.Quantidade==maxVenda)}).ToList();



            Console.WriteLine(vendas);


        }
    }
}
