using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectAD.Models;

namespace ProjectAD.Models.ViewModels
{
    public class PaymentPart
    {
        public Payment payment { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}