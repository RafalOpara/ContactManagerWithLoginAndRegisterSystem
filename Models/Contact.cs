﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CustomIdentity.Models
{
    public class Contact
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }


    

    }
}
