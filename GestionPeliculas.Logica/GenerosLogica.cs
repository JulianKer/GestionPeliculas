using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPeliculas.Data.EF;

namespace GestionPeliculas.Logica
{

    public interface IGenerosLogica
    {
        List<Genero> obtenerTodosLosGeneros();
    }
    public class GenerosLogica : IGenerosLogica
    {
        public GestionPeliculasContext _context;
        public GenerosLogica(GestionPeliculasContext context)
        {
            this._context = context;
        }

        public List<Genero> obtenerTodosLosGeneros()
        {
            return this._context.Generos.ToList();
        }
    }
}
