using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using peliculas.Data;
using Pelis.Data.Interfaces;
using Pelis.Models;

namespace Pelis.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly ApplicationDbContext _context;
        public ApiRepository(ApplicationDbContext context)
        {
        
        _context = context;
        }
    public void Add<P>(P entity) where P : class
    {
            _context.Add(entity);

        }

    public void Delete<P>(P entity) where P : class
    {
            _context.Remove(entity);
        }

        public async Task<List<Pelicula>> GetPeliculaByGeneroAsync(string Genero)
        {
           var pelicula = await _context.Peliculas.Where(x => x.Genero == Genero).ToListAsync();
            return pelicula;
        }

        public async Task<Pelicula> GetPeliculaByIdAsync(int Id)
    {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(x => x.Id == Id);
            return pelicula;
        }

    public async Task<Pelicula> GetPeliculaByNombreAsync(string Titulo)
    {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(a => a.Titulo == Titulo);
            return pelicula;
        }

    public async Task<IEnumerable<Pelicula>> GetPeliculasAsync()
    {
            var peliculas = await _context.Peliculas.ToListAsync();
            return peliculas;
        }

    public async  Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
       var usuario = await _context.Usuarios.ToListAsync();
            return usuario;
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int Id)
    {
         var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
            return usuario;
    }

    public async Task<Usuario> GetUsuarioByNombreAsync(string Nombre)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(a => a.Nombre == Nombre);
            return usuario;
        }

    public async Task<bool> SaveAll()
    {
            return await _context.SaveChangesAsync() > 0;
        }
}
}