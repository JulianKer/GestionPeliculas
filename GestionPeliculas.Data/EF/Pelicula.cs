using System;
using System.Collections.Generic;

namespace GestionPeliculas.Data.EF;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Titulo { get; set; } = null!;

    public int AnioEstreno { get; set; }

    public int IdGenero { get; set; }

    public bool Eliminado { get; set; }

    public virtual Genero IdGeneroNavigation { get; set; } = null!;
}
