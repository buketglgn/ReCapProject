using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
   public class UserForRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
