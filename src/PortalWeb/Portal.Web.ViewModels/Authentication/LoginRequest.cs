using System.ComponentModel.DataAnnotations;

namespace Portal.Web.ViewModels.Authentication
{
    /// <summary>
    /// login request
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
