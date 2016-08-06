﻿using Portal.DataObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace Portal.Web.ViewModels.MemberChildBenefit
{
    public class SupportViewModel
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [DisplayName("Member's name")]
        public string MemberName { get; set; }

        public decimal Amount { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Year")]
        public string Year { get; set; }

        [DisplayName("Added Date")]
        public string AddedDate { get; set; }

        [DisplayName("Added by")]
        public string AddedBy { get; set; }

        public int AddedById { get; set; }

        public bool Paid { get; set; }
    }

    public class ViewSupport
    {
        public string MemberId { get; set; }

        public string MemberName { get; set; }

        public MembershipType MembershipType { get; set; }

        public string Address { get; set; }

        public decimal TotalSupportAmount { get; set; }

        public List<SupportViewModel> Supports { get; set; }
    }
}
