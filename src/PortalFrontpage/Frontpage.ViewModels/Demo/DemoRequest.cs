using System.ComponentModel;

namespace Frontpage.ViewModels.Demo
{
    public class DemoRequest
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string Firstname { get; set; }

        [DisplayName("Last name")]
        public string Lastname { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Your association name")]
        public string AsscName { get; set; }

        [DisplayName("Association Address")]
        public string AsscAddr { get; set; }

        [DisplayName("Country")]
        public string AsscCountry { get; set; }

        public bool Completed { get; set; }
        public string CompletionDate { get; set; }
        public bool Schedule { get; set; }
        public string ScheduleDate { get; set; }
        
        public string Telephone { get; set; }
    }
}
