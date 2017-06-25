namespace WPR.Entities.Models
{
    using System.Collections.Generic;

    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
    
        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
