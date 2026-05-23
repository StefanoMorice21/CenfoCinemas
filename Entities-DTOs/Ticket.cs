using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class Ticket
    {
        public double Price { get; set; }
        public DateTime Schedule {  get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Movie MovieName { get; set; }
    }
}
