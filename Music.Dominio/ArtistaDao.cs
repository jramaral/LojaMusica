using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Contexto;
using System.Data.Entity;

namespace Music.Dominio
{
    public class ArtistaDao
    {
        private lojaMusicaEntities contexto;

        public ArtistaDao()
        {
            contexto = new lojaMusicaEntities();
        }
        public List<Artista> BuscarTodos()
        {
            return contexto.Artista.Where(a => a.ArtistaId > 270).ToList();
        }

        public void Salvar(Artista artista)
        {
            contexto.Artista.Add(artista);
            contexto.SaveChanges();
        }
        public Artista BuscarPorId(int id)
        {
            return contexto.Artista.FirstOrDefault(a => a.ArtistaId == id);
        }
        public void SalvarAlteracao(Artista artista)
        {
            contexto.Entry(artista).State = EntityState.Modified;

            contexto.SaveChanges();
        }
    }
}
