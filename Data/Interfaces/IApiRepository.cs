using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pelis.Models;

namespace Pelis.Data.Interfaces
{
    public interface IApiRepository
    {
        void Add<P>(P entity) where P : class;
        void Delete<P>(P entity) where P : class;

        Task<bool> SaveAll();
        Task<IEnumerable<Usuario>> GetUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(int Id);
        Task<Usuario> GetUsuarioByNombreAsync(string Nombre);
        Task<IEnumerable<Pelicula>> GetPeliculasAsync();
        Task<Pelicula> GetPeliculaByIdAsync(int Id);
        Task<Pelicula> GetPeliculaByNombreAsync(string Titulo);
        Task<List<Pelicula>> GetPeliculaByGeneroAsync(string Genero);


    }
}