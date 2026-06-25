using CoreApp;
using Entities_DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var tm = new TicketManager();
                var lstResults = tm.RetrieveAllTickets();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(int id)
        {
            try
            {
                var tm = new TicketManager();
                var ticket = tm.RetrieveTicketById(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                var tm = new TicketManager();
                tm.CreateTicket(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Ticket ticket)
        {
            try
            {
                var tm = new TicketManager();
                tm.UpdateTicket(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Ticket ticket)
        {
            try
            {
                var tm = new TicketManager();
                tm.DeleteTicket(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
