using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class SubscriptionViewModel
    {
        public int SubscriptionId { get; set; }
        public int AssocId { get; set; }
        public bool IsActive { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
