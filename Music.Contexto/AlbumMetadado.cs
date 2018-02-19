using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Contexto
{
    [MetadataType(typeof(AlbumMetadado))]
    public partial class Album
    {

    }
    public class AlbumMetadado
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Título")]
        public string Titulo { get; set; }

        public int ArtistaId { get; set; }

        public virtual Artista Artista { get; set; }
        public virtual ICollection<Faixa> Faixa { get; set; }
    }
}
