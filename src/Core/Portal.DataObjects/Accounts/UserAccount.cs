﻿namespace Portal.DataObjects.Accounts
{
    public class UserAccount : BaseUserInfo
    {
        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string Biography { get; set; }

        public string Telephone { get; set; }

        public string EmergencyTel { get; set; }

        public string Address { get; set; }
    }

    public class BaseUserInfo
    {
        public int AccountId { get; set; }

        public bool IsAdmin { get; set; }

        public int LoginRole { get; set; }

        public bool CanInvest { get; set; }

        public bool CanDoChildBenefit { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MembershipType { get; set; }

        public string ProfilePicUrl { get; set; }

        public int AsscId { get; set; }
    }
}
