using GestionPeliculas.Data.EF;
using GestionPeliculas.Logica;
using GestionPeliculas.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionPeliculas.Web.Controllers
{
    public class PeliculasController : Controller
    {
        public IPeliculasLogica _peliculasLogica;
        public IGenerosLogica _generosLogica;
        public PeliculasController(IPeliculasLogica peliculasLogica, IGenerosLogica generosLogica) { 
            this._peliculasLogica = peliculasLogica;
            this._generosLogica = generosLogica;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            ViewBag.Generos = this._generosLogica.obtenerTodosLosGeneros();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(PeliculasModel peli)
        {
            if (!ModelState.IsValid)
            {
                TempData["msj"] = "Falló al intentar agregar una pelicula";
            }

            Pelicula peliculaMapeada = new Pelicula();
            peliculaMapeada.Titulo = peli.Titulo;
            peliculaMapeada.IdGenero = peli.IdGenero;
            peliculaMapeada.AnioEstreno = peli.AnioEstreno;
            peliculaMapeada.Eliminado = false;

            this._peliculasLogica.agregarPeli(peliculaMapeada);

            TempData["msj"] = "Pelicula agregada con exito";
            return RedirectToAction("Visualizar");
        }

        public IActionResult Visualizar(int? idGenero)
        {
            ViewBag.Generos = this._generosLogica.obtenerTodosLosGeneros();
            List<Pelicula> peliculas;

            if (idGenero.HasValue)
            {
                peliculas = this._peliculasLogica.obtenerPeliculasPorGenero(idGenero);
            }
            else{
                peliculas = this._peliculasLogica.obtenerPeliculas();
            }
            ViewBag.IdGenero = idGenero ?? 0;
            return View(peliculas);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            this._peliculasLogica.eliminarPeliculaPorId(id);
            TempData["msj"] = "Pelicula eliminada con éxito!";
            return RedirectToAction("Visualizar");
        }
    }
}
