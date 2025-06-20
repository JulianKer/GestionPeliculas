using GestionPeliculas.Data.EF;

namespace GestionPeliculas.Logica
{

    public interface IPeliculasLogica
    {
        void agregarPeli(Pelicula peli);
        void eliminarPeliculaPorId(int id);
        Pelicula buscarPeliculaporId(int id);
        List<Pelicula> obtenerPeliculas();
        List<Pelicula> obtenerPeliculasPorGenero(int? idGenero);
    }


    public class PeliculasLogica : IPeliculasLogica
    {

        public GestionPeliculasContext _context;
        public PeliculasLogica(GestionPeliculasContext context)
        {
            this._context = context;
        }


        public void agregarPeli(Pelicula peli)
        {
            this._context.Peliculas.Add(peli);
            this._context.SaveChanges();
        }

        public void eliminarPeliculaPorId(int id)
        {
            Pelicula peli = buscarPeliculaporId(id);

            if (peli != null)
            {
                peli.Eliminado = true;
                this._context.SaveChanges();
            }
        }

        public Pelicula buscarPeliculaporId(int id)
        {
            return this._context.Peliculas.Find(id);
        }

        public List<Pelicula> obtenerPeliculas()
        {
            return this._context.Peliculas.Where(p => !p.Eliminado).ToList();
        }

        public List<Pelicula> obtenerPeliculasPorGenero(int? idGenero)
        {
            return this._context.Peliculas.Where(p => !p.Eliminado && p.IdGenero == idGenero).ToList();
        }
    }
}
