using GestionPeliculas.Data.EF;

namespace GestionPeliculas.Web.Models
{
    public class PeliculasModel
    {

        public string Titulo { get; set; } = null!;

        public int AnioEstreno { get; set; }

        public int IdGenero { get; set; }

    }
}
