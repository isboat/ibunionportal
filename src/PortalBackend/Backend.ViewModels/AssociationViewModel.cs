﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class AssociationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string JoinDate { get; set; }

        public string Password { get; set; }

        public string PaymentType { get; set; }

        public bool IsActive { get; set; }
    }
}
