using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreApp
{
    public class TicketManager
    {
        private void ValidateTicket(Ticket t)
        {
            // Regla de formato 1: Campos obligatorios no vacios
            if (string.IsNullOrEmpty(t.TicketCode) || string.IsNullOrEmpty(t.SeatNumber) ||
                string.IsNullOrEmpty(t.Status))
            {
                throw new Exception("Todos los campos obligatorios deben estar completos.");
            }

            if (t.MovieId <= 0 || t.UserId <= 0)
            {
                throw new Exception("El MovieId y UserId deben ser valores validos.");
            }

            // Regla de formato 2: Price debe ser positivo y en rango razonable
            if (t.Price <= 0 || t.Price > 100000)
            {
                throw new Exception("El precio debe ser positivo y no mayor a 100000.");
            }

            // Regla de formato 3: TicketCode debe cumplir un patron valido (alfanumerico, 3-25 caracteres)
            var ticketCodePattern = @"^[A-Za-z0-9]{3,25}$";
            if (!Regex.IsMatch(t.TicketCode, ticketCodePattern))
            {
                throw new Exception("El codigo de ticket debe ser alfanumerico y tener entre 3 y 25 caracteres.");
            }

            // Regla de negocio: No se puede emitir un boleto para una funcion ya transcurrida
            if (t.ShowDateTime < DateTime.Now)
            {
                throw new Exception("No se puede emitir un boleto para una funcion que ya paso.");
            }

            // Regla de negocio: No se puede emitir un boleto si se alcanzo el aforo maximo (50 por funcion)
            var tCrud = new TicketCrudFactory();
            var allTickets = tCrud.RetrieveAll<Ticket>();
            int aforoMaximo = 50;
            int ticketsVendidos = allTickets
                .Where(x => x.MovieId == t.MovieId && x.ShowDateTime == t.ShowDateTime)
                .Count();

            if (ticketsVendidos >= aforoMaximo)
            {
                throw new Exception("No se puede emitir el boleto, se alcanzo el aforo maximo de " + aforoMaximo + " para esta funcion.");
            }
        }

        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }

        public Ticket RetrieveTicketById(int id)
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveById<Ticket>(id);
        }

        public void CreateTicket(Ticket t)
        {
            ValidateTicket(t);
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }

        public void UpdateTicket(Ticket t)
        {
            ValidateTicket(t);
            var tCrud = new TicketCrudFactory();
            tCrud.Update(t);
        }

        public void DeleteTicket(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Delete(t);
        }
    }
}
