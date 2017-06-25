using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public class MatterDatasetParms
    {
        public string UserName { get; set; }
        public string MatterId { get; set; }
        public List<int> CustodianIds { get; set; }
    }
}