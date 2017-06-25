using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public partial class MatterCustodianSummary
    {
        public string MatterId { get; set; }
        public string Name { get; set; }
        public Int32 Count { get; set; }
        public decimal SizeGB { get; set; }
    }
}