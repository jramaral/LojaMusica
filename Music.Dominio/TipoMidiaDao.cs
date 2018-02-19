using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Contexto;
using System.Data.Entity;

namespace Music.Dominio
{
    public class TipoMidiaDao
    {
        private lojaMusicaEntities contexto;
        public TipoMidiaDao()
        {
            contexto = new lojaMusicaEntities();
            
        }

        public List<TipoMidia> BuscarTodos()
        {
            return contexto.TipoMidia.ToList();
        }
    }
}
