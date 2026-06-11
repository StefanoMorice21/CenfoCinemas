using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRUD
{
    internal class MovieCrudFactory : CrudFactory
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
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddDateTimeParameter("P_RELEASE_DATE", movie.ReleaseDate);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);
            sqlDao.ExecuteProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
