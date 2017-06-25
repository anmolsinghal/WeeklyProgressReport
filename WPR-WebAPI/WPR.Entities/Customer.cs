namespace WPR.Entities.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class Customer
    {
        public Customer()
        {
            Projects = new HashSet<Project>();
        }
    
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Fax { get; set; }
        public string EmailId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
