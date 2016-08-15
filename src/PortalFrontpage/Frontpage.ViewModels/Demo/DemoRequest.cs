using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frontpage.ViewModels.Demo
{
    public class DemoRequest
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        [Required]
        public string Firstname { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string Lastname { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Your association name")]
        public string AsscName { get; set; }

        [Required]
        [DisplayName("Association Address")]
        public string AsscAddr { get; set; }

        [DisplayName("Country")]
        public string AsscCountry { get; set; }

        public bool Completed { get; set; }
        public string CompletionDate { get; set; }
        public bool Schedule { get; set; }
        public string ScheduleDate { get; set; }
        
        [Required]
        public string Telephone { get; set; }
    }
}
