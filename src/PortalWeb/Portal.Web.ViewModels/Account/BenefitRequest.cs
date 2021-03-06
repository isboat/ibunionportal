﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portal.Web.ViewModels.Account
{
    public class BenefitRequest : BaseRequest
    {
        public int BenefitId { get; set; }

        [DisplayName("Benefit type")]
        [Required]
        public string BenefitType { get; set; }

        public IEnumerable<SelectListItem> BenefitTypeOptions { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
