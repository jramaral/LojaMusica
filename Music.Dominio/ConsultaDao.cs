using Music.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dominio
{
    public class ConsultaDao
    {
        private lojaMusicaEntities contexto;
        const int REG_MAX = 10;

        public ConsultaDao()
        {
            contexto = new lojaMusicaEntities();
        }

        //Para criar o tipo de contonsulta
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

        public List<Resultado> getResultado(int id)
        {

            
            var query = (from faixas in contexto.ItemNotaFiscal
                         group faixas by new { faixas.FaixaId }
                         into Agrupados
                         let qtde = contexto.ItemNotaFiscal.Count(f => f.FaixaId == Agrupados.Key.FaixaId)
                         let faixa = contexto.ItemNotaFiscal.FirstOrDefault(f => f.FaixaId.Equals(Agrupados.Key.FaixaId))
                         select new Resultado
                         {
                             Codigo = Agrupados.Key.FaixaId,
                             Nome = faixa.Faixa.Nome,
                             Quantidade = qtde,
                             Total = (faixa.PrecoUnitario * qtde)
                         });


            var query2 = (from artistas in contexto.ItemNotaFiscal
                                      group artistas by new { artistas.Faixa.Album.ArtistaId }
                                      into agrupados
                                      let qtde = contexto.ItemNotaFiscal.Count(f => f.Faixa.Album.Artista.ArtistaId == agrupados.Key.ArtistaId)
                                      let artista = contexto.ItemNotaFiscal.FirstOrDefault(f => f.Faixa.Album.Artista.ArtistaId.Equals(agrupados.Key.ArtistaId))
                                      select new Resultado
                                      {
                                          Codigo=agrupados.Key.ArtistaId,
                                          Nome=artista.Faixa.Album.Artista.Nome,
                                          Quantidade=qtde
                                      });

           switch (id)
            {
                case 1: //Faixas mais vendidas
                    query = query.OrderByDescending(o => o.Quantidade).ThenBy(o => o.Nome).Take(REG_MAX);
                    break;

                  
                case 2: //Faixas menos vendidas
                    query = query.OrderBy(o => o.Quantidade).ThenBy(o => o.Nome).Take(REG_MAX);
                    break;

                case 3: //Artistas mais vendidos
                    query2 = query2.OrderByDescending(o => o.Quantidade).ThenBy(o => o.Nome).Take(REG_MAX);
                    break;

                case 4: //Artistas menos vendidos
                    query2 = query2.OrderBy(o => o.Quantidade).ThenBy(o => o.Nome).Take(REG_MAX);
                    break;
            }


            if (id==1 || id==2) //Escolhas por Faixas
            {
                return query.ToList();
            }
            else   //Escolhas por Artistas
            {
                return query2.ToList();
            }
        }

       
    }
}
