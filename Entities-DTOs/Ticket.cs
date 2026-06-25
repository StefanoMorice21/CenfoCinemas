using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class Ticket : BaseDTO
    {
        public string TicketCode { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime ShowDateTime { get; set; }
        public string SeatNumber { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
