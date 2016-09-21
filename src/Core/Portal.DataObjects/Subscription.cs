using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataObjects
{
    public class Subscription
    {
        public int Id { get; set; }
        public int AssocId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
