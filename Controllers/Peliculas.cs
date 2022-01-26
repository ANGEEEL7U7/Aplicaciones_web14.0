using System;
namespace pelicula.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Pelis.Data.Interfaces;
    using Pelis.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class peliculaController : ControllerBase
    {
        private readonly IApiRepository _repo;


        public peliculaController(IApiRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetpeliculasAsync()
        {

            var peliculas = await _repo.GetPeliculasAsync();

            return Ok(peliculas);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Pelicula pelicula)
        {

            pelicula.Fecha = DateTime.Now;

            _repo.Add(pelicula);
            if (await _repo.SaveAll())
                return Ok(pelicula);
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetpeliculasAsync(int id)
        {

            var peliculas = await _repo.GetPeliculaByIdAsync(id);
            if (peliculas == null)
                return NotFound("No existe el producto");

            return Ok(peliculas);
        }
        
        

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id){

            var pelicula = await _repo.GetPeliculaByIdAsync(id);
            if(pelicula == null)
                return NotFound("Producto no encontrado");

            _repo.Delete(pelicula);
            if(!await _repo.SaveAll())
                return BadRequest("no se pudo eliminar el producto");
            return Ok("producto borrado");
        }
        
        [HttpGet("nombre/{Titulo}")]
        public async Task<IActionResult> Get(string Titulo)
        {

            var peliculas = await _repo.GetPeliculaByNombreAsync(Titulo);
            if (peliculas == null)
                return NotFound("No existe el producto");

            return Ok(peliculas);
        }    
        [HttpGet("genero/{Genero}")]
        public async Task<IActionResult> GetGenero(string Genero)
        {

            var peliculas = await _repo.GetPeliculaByGeneroAsync(Genero);
            if (peliculas == null)
                return NotFound("No existe el producto");

            return Ok(peliculas);
        }  

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pelicula pelicula)
        {

            if(id != pelicula.Id){
                return BadRequest("El id no coincide");
            }
            var peliculaToUpdate = await _repo.GetPeliculaByIdAsync(pelicula.Id);

            if (peliculaToUpdate == null)
                return BadRequest();

            
            peliculaToUpdate.Titulo = pelicula.Titulo;
            peliculaToUpdate.Director = pelicula.Director;
            peliculaToUpdate.Genero = pelicula.Genero;
            peliculaToUpdate.Puntuacion = pelicula.Puntuacion;
            peliculaToUpdate.Rating = pelicula.Rating;
            
            if (await _repo.SaveAll())
                return NoContent();

            return Ok(peliculaToUpdate);
        }  

    }
}