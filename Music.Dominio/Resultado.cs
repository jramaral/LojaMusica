using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dominio
{
    public class Resultado
    {
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Genero { get; set; }
        public decimal Total { get; set; }

    }
}
