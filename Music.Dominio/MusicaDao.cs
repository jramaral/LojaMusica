using Music.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dominio
{
    public class MusicaDao
    {
        private lojaMusicaEntities contexto;
        public MusicaDao()
        {
            contexto = new lojaMusicaEntities();
        }

        public Faixa BuscarPorId(int id)
        {
            return contexto.Faixa.FirstOrDefault(a => a.FaixaId == id);
        }

        public List<Resultado> Pesquisar(Faixa faixa)
        {
            return (from f in contexto.Faixa where f.AlbumId == faixa.AlbumId select new Resultado { Codigo=f.FaixaId, Nome=f.Nome, Preco=f.PrecoUnitario, Genero=f.Genero.Nome}).ToList();
      
        }
        public List<Faixa> BuscarTodos()
        {
            return contexto.Faixa.Where(a => a.FaixaId > 340).ToList();
        }

        public void  Salvar(Faixa faixa)
        {
            contexto.Faixa.Add(faixa);
            contexto.SaveChanges();
            
        }

        public void SalvarAlteracao(Faixa faixa)
        {
            contexto.Entry(faixa).State = EntityState.Modified;
            contexto.SaveChanges();
           

        }

        public bool Excluir(int id)
        {
            try
            {
                var faixa = contexto.Faixa.Find(id);
                contexto.Faixa.Remove(faixa);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }

    }
}
