using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Contexto;
using System.Data.Entity;

namespace Music.Dominio
{
    public class GeneroDao
    {
        private lojaMusicaEntities contexto;

        public GeneroDao()
        {
            contexto = new lojaMusicaEntities();
        }
        public List<Genero> BuscarTodos()
        {
            return contexto.Genero.ToList();
        }
    }
}
