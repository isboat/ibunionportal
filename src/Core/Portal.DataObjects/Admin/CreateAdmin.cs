﻿namespace Portal.DataObjects.Admin
{
    public class CreateAdmin
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public int Role { get; set; }

        public string Password { get; set; }
    }
}
