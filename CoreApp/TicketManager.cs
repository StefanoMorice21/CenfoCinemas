using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class TicketManager
    {
        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }
        public void CreateTicket(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }
    }
}
