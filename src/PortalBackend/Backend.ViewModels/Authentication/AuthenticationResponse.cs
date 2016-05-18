namespace Backend.ViewModels.Authentication
{
    public class AuthenticationResponse
    {

        /// <summary>
        /// Account key of logged in user
        /// </summary>
        public string AccountKey { get; set; }

        /// <summary>
        /// Login Message
        /// </summary>
        public string Message { get; set; }

        public string FormsAuthCookieName { get; set; }

        public string FormsAuthCookieValue { get; set; }
    }
}
