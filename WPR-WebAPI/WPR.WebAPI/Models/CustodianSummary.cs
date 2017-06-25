using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public partial class CustodianSummary
    {
        public string custodianId { get; set; }
        public string custodianName { get; set; }
        public bool collected { get; set; }
        public bool ingested { get; set; }
        public bool processed { get; set; }
        public bool reviewed { get; set; }
        public bool produced { get; set; }
        public bool selected { get; set; }
    }
}