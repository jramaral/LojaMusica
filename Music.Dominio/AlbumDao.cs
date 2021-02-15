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

           
            var reg = contexto.Album.Count();
            var temp = reg -10;

            return contexto.Album.Where(a => a.AlbumId > temp).ToList();


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

        public bool Excluir(int id)
        {
            try
            {
                var album = contexto.Album.Find(id);
                contexto.Album.Remove(album ?? throw new InvalidOperationException());
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
