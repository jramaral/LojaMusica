using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Contexto;
using System.Data.Entity;

namespace Music.Dominio
{
    public class AlbumDao
    {
        private lojaMusicaEntities contexto;

        public AlbumDao()
        {
            contexto = new lojaMusicaEntities();
        }

        public Album BuscarPorId(int id)
        {
            return contexto.Album.FirstOrDefault(a => a.AlbumId == id);
        }
        public List<Album> BuscarTodos()
        {
            return contexto.Album.Where(a=> a.AlbumId<10).ToList();
        }
        
        public void Salvar(Album album)
        {
            contexto.Album.Add(album);
            contexto.SaveChanges();
        }
        public void SalvarAlteracao(Album album)
        {
            contexto.Entry(album).State = EntityState.Modified;
            
            contexto.SaveChanges();
        }
    }
}
