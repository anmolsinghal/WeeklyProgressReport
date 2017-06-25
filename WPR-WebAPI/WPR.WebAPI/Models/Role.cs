using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}