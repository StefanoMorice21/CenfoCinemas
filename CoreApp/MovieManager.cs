using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class MovieManager
    {
        private void ValidateMovie(Movie m)
        {
            // Regla de formato 1: Campos obligatorios no vacios
            if (string.IsNullOrEmpty(m.Title) || string.IsNullOrEmpty(m.Sinopsis) ||
                string.IsNullOrEmpty(m.Genre) || string.IsNullOrEmpty(m.Clasification) ||
                string.IsNullOrEmpty(m.Image) || string.IsNullOrEmpty(m.Status))
            {
                throw new Exception("Todos los campos obligatorios deben estar completos.");
            }

            // Regla de formato 2: Duration debe ser positivo y en rango razonable
            if (m.Duration <= 0 || m.Duration > 600)
            {
                throw new Exception("La duracion debe ser un valor positivo y no mayor a 600 minutos.");
            }

            // Regla de negocio: La duracion no puede ser menor a 60 minutos
            if (m.Duration < 60)
            {
                throw new Exception("La duracion de la pelicula no puede ser menor a 60 minutos.");
            }
        }

        public List<Movie> RetrieveAllMovies()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();
        }

        public Movie RetrieveMovieById(int id)
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveById<Movie>(id);
        }

        public void CreateMovie(Movie m)
        {
            ValidateMovie(m);
            var mCrud = new MovieCrudFactory();
            mCrud.Create(m);
        }

        public void UpdateMovie(Movie m)
        {
            ValidateMovie(m);
            var mCrud = new MovieCrudFactory();
            mCrud.Update(m);
        }

        public void DeleteMovie(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            mCrud.Delete(m);
        }
    }
}
