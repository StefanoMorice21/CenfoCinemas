using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class User : BaseDTO
    {
        public string UserCode {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public int Phone {  get; set; }

    }
}
