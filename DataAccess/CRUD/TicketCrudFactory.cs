using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRUD
{
    public class TicketCrudFactory : CrudFactory
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
            sqlOperation.AddDoubleParameter("P_PRICE", ticket.Price);
            sqlOperation.AddDateTimeParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);
            sqlOperation.AddIntParameter("P_MOVIE_ID", ticket.MovieId);
            sqlDao.ExecuteProcedure(sqlOperation);
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
            var lstTickets = new List<T>();
            var operation = new Operation();
            operation.ProcedureName = "RET_ALL_TICKETS_PR";
            var lstResults = sqlDao.ExecuteQueryProcedure(operation);
            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var ticket = BuildTicket(result);
                    lstTickets.Add((T)Convert.ChangeType(ticket, typeof(T)));
                }
            }
            return lstTickets;
        }

        public override T RetrieveById<T>(int id)
        {
            var operation = new Operation();
            operation.ProcedureName = "RET_TICKET_BY_ID_PR";
            operation.AddIntParameter("P_ID", id);

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var ticket = BuildTicket(row);

                return (T)Convert.ChangeType(ticket, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        private Ticket BuildTicket(Dictionary<string, object> row)
        {
            var ticket = new Ticket()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Price = (double)row["Price"],
                Schedule = (DateTime)row["Schedule"],
                Date = (DateTime)row["Date"],
                Type = (string)row["Type"],
                MovieId = (int)row["MovieId"]
         
            };
            return ticket;

        }
    }
}
