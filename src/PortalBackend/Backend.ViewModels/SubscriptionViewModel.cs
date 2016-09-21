using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class SubscriptionViewModel
    {
        public int Id { get; set; }
        public int AssocId { get; set; }

        public bool IsActive
        {
            get
            {
                DateTime d;
                if (!string.IsNullOrEmpty(EndDate) && DateTime.TryParse(EndDate, out d))
                {
                    return  d > DateTime.Now;
                }

                return false;
            }
        }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
