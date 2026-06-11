using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRUD
{
    internal class TicketCrudFactory : CrudFactory
    {
        public TicketCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;
            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "CRE_TICKET_PR";
            sqlOperation.AddDoubleParameter("PRICE", ticket.Price);
            sqlOperation.AddDateTimeParameter("SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("DATE", ticket.Date);
            sqlOperation.AddStringParameter("TYPE", ticket.Type);
            sqlOperation.AddIntParameter("MOVIE_ID", ticket.MovieId);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "DEL_TICKET_PR";
            sqlOperation.AddIntParameter("P_ID", ticket.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
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
