using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class MovieManager
    {
        public List<Movie> RetrieveAllMovies()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();
        }
        public void CreateMovie(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            mCrud.Create(m);
        }
    }
}
