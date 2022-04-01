using System;
using System.Collections.Generic;
using System.Text;

namespace Infront.Domain.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
