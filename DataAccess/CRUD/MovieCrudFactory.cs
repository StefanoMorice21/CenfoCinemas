using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;
            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";
            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASIFICATION", movie.Clasification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);
            sqlDao.ExecuteProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "DEL_MOVIE_PR";
            sqlOperation.AddIntParameter("P_ID", movie.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();
            var operation = new Operation();
            operation.ProcedureName = "RET_ALL_MOVIE_PR";
            var lstResults = sqlDao.ExecuteQueryProcedure(operation);
            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var movie = BuildMovie(result);
                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }
            return lstMovies;
        }

        public override T RetrieveById<T>(int id)
        {
            var operation = new Operation();
            operation.ProcedureName = "RET_MOVIE_BY_ID_PR";
            operation.AddIntParameter("P_ID", id);

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movie = BuildMovie(row);

                return (T)Convert.ChangeType(movie, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        private Movie BuildMovie(Dictionary<string, object> row)
        {
            var movie = new Movie()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Title = (string)row["Title"],
                Sinopsis = (string)row["Sinopsis"],
                Genre = (string)row["Genre"],
                Duration = (int)row["Duration"],
                Clasification = (string)row["Clasification"],
                Image = (string)row["Image"],
                Status = (string)row["Status"]
            };
            return movie;

        }
    }
}
