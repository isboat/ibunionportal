﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class AddPaymentRequest
    {
        public string Month { get; set; }

        public int Year { get; set; }

        public decimal Amount { get; set; }

        public int AssocId { get; set; }
    }
}
