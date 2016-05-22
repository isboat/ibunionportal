using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataObjects
{
    public class Demo
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string AsscAddr { get; set; }
        public string AsscCountry { get; set; }
        public bool Completed { get; set; }
        public string CompletionDate { get; set; }
        public bool Schedule { get; set; }
        public string ScheduleDate { get; set; }
    }

    public class DemoSummary
    {
        public int Id { get; set; }
        public string AsscName { get; set; }
        public string Telephone { get; set; }
    }
}
