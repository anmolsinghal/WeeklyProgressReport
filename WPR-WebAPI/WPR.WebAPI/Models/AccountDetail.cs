using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerView.WebAPI.Models
{
    public class AccountDetail
    {
        public Guid? userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string oldPassword { get; set; }
        public string email { get; set; }
        public string userRole { get; set; }
        public bool isAdmin { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string loginToken { get; set; }
        public string passwordToken { get; set; }
        public DateTime passwordTokenCreationDate { get; set; }
        public bool isValid { get; set; }
        public Guid? adminUserID { get; set; }
    }
}