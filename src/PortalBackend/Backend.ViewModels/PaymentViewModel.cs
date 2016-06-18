using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public int AssocId { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public bool Paid { get; set; }
        public string DatePaid { get; set; }
    }
}
