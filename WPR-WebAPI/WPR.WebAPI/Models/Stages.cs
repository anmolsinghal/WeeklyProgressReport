using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public partial class Stages
    {
        public int collected { get; set; }
        public int ingested { get; set; }
        public int processed { get; set; }
        public int reviewed { get; set; }
        public int produced { get; set; }
    }
}